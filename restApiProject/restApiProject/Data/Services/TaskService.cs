using ClassLibraryModels;
using Microsoft.EntityFrameworkCore;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public class TaskService : EntityBaseRepository<Taskk>, ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaskService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ServiceResponse<string>> AddTaskAsync(NewTaskVM data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == data.EmployeeId && x.Role == "Employee");
                var project = await _context.Projects.SingleAsync(x => x.Id == data.ProjectId);
                var taskName = await _context.Tasks.CountAsync(x => x.Name == data.Name);

                if (user != null && project != null)
                {
                    var empProjects = await _context.Employee_Projects.CountAsync(x => x.EmployeeId == data.EmployeeId && x.ProjectId == data.ProjectId);
                    if (empProjects > 0)
                    {
                        if (taskName != 0)
                        {
                            var tasku = new Taskk()
                            {
                                Name = data.Name,
                                IsCompleted = false,
                                DateCreated = DateTime.Now,
                                Projectid = data.ProjectId,
                                EmployeeId = data.EmployeeId
                            };
                            //var emp = _context.Projects.FirstOrDefault(c => c.Id == id);
                            await _context.Tasks.AddAsync(tasku);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            response.Message = "This task s name already exists !";
                        }
                    }
                    else
                    {
                        response.Message = "This employee is not part of this project";
                    }

                }
                else
                {
                    response.Message = "Employee or project does not exist";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }


        //Administrator can update tasks and assign them to others
        public async Task<ServiceResponse<string>> UpdateTaskAsync(int id, NewTaskVM data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var dbTask = await _context.Tasks.FirstOrDefaultAsync(n => n.Id == id);
                if (dbTask != null)
                {
                    var existingTaskName = await _context.Tasks.CountAsync(n => n.Name == data.Name);
                    if (existingTaskName == 0)
                    {
                        dbTask.Name = data.Name;
                        dbTask.DateUpdated = DateTime.Now;
                        dbTask.EmployeeId = data.EmployeeId;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        response.Message = "This task name already exists. Try another one !";
                    }

                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;

        }

        //[HttpPost]

        //public Task<ServiceResponse<string>> Employee_CreateTask(EmployeeNewTask data)
        //{
        //    ServiceResponse<string> response = new ServiceResponse<string>();
        //    try
        //    {
        //        var tasku = new Taskk()
        //        {
        //            Name = data.Name,
        //            IsCompleted = false,
        //            DateCreated = DateTime.Now,
        //            Projectid = data.ProjectId,
        //            EmployeeId = null
        //        };

        //        //var emp = _context.Projects.FirstOrDefault(c => c.Id == id);
        //        await _context.Tasks.AddAsync(tasku);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}




        public async Task<ServiceResponse<string>> MarkTaskAsCompleted(int id)
        {
            var task = _context.Tasks.FirstOrDefault(c => c.Id == id);
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                if (task != null)
                {

                    if (task.IsCompleted == false)
                    {
                        task.IsCompleted = true;
                        task.DateUpdated = DateTime.Now;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<List<Taskk>> GetTasksOfEmployees()
        {
            var empId = GetUserId();
            var tasksOfEmployee = await _context.Tasks.Where(x => x.EmployeeId == empId).ToListAsync();

            return tasksOfEmployee;
        }

        public async Task<List<Taskk>> GetTasksProjectOfEmployee(int projectId)
        {
            int employeeId = GetUserId();
            var tasksOfPro = await _context.Tasks.Where(x => x.EmployeeId == employeeId && x.Projectid == projectId).ToListAsync();

            return tasksOfPro;
        }


        public async Task<List<Employee_Project>> GetProjectsOfEmployee()
        {
            int employeeId = GetUserId();
            var projects = await _context.Employee_Projects.Where(x => x.EmployeeId == employeeId).ToListAsync();

            return projects;
        }


        public async Task<ServiceResponse<string>> Employee_CreateTask(EmployeeNewTask data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                int UserId = GetUserId();
                var employeeProjects = GetProjectsOfEmployee();
                var project = await _context.Employee_Projects.FirstOrDefaultAsync(x => x.ProjectId == data.ProjectId);
                var employee = await _context.Users.SingleAsync(x => x.Id == data.EmployeeId);
                var taskName = await _context.Tasks.CountAsync(x => x.Name == data.Name);

                if (project != null)
                {
                    var existEmp_pro = _context.Employee_Projects.Count(x => x.ProjectId == project.ProjectId && x.EmployeeId == UserId);
                    if (existEmp_pro == 1)
                    {
                        var emp_assignedTask = await _context.Employee_Projects.FirstOrDefaultAsync(x => x.EmployeeId == employee.Id && x.ProjectId == project.ProjectId);
                        if (emp_assignedTask != null)
                        {
                            if (taskName == 0)
                            {
                                var tasku = new Taskk()
                                {
                                    Name = data.Name,
                                    IsCompleted = false,
                                    DateCreated = DateTime.Now,
                                    Projectid = data.ProjectId,
                                    EmployeeId = data.EmployeeId
                                };
                                await _context.Tasks.AddAsync(tasku);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                response.Message = "This task's name already exists !";
                            }
                        }
                        else
                        {
                            response.Message = "You cannot assign tasks to employees that are not part of this project";
                        }

                    }
                    else
                    {
                        response.Message = "You cannot add tasks to a project you are not part of";
                    }
                }
                else
                {
                    response.Message = "This project does not exist";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }


        //employee... 
        public async Task<ServiceResponse<string>> AddEmployeeToTaskAsync(int taskId, AddTaskToEmployee data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var task = await _context.Tasks.SingleAsync(x => x.Id == taskId);

                if (task != null)
                {
                    var employee = await _context.Users.CountAsync(x => x.Id == data.EmployeeId && x.Role == "Employee");
                    if (employee == 1)
                    {
                        if (task.EmployeeId == null || task.EmployeeId == Int32.Parse(""))
                            task.DateUpdated = DateTime.Now;
                        task.EmployeeId = data.EmployeeId;

                        await _context.SaveChangesAsync();
                    }

                    else
                    {
                        response.Message = "This employee does not exist";
                    }

                }
                else
                {
                    response.Message = "Task does not exist";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> MarkTaskAsCompletedEmployee(int id)
        {
            var UserId = GetUserId();


            var task = _context.Tasks.FirstOrDefault(c => c.Id == id && c.EmployeeId == UserId);
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                if (task != null)
                {

                    if (task.IsCompleted == false)
                    {
                        task.IsCompleted = true;
                        task.DateUpdated = DateTime.Now;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }


    }
}
