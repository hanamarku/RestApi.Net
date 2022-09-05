using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public class ProjectService : EntityBaseRepository<Project>, IProjectService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProjectService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ServiceResponse<string>> AddEmployeeToProject(int ProjectId, int EmployeeId)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(c => c.Id == ProjectId);
                var employee = await _context.Users.FirstOrDefaultAsync(c => c.Id == EmployeeId && c.Role == "Employee");

                var exist = await _context.Employee_Projects.CountAsync(c => c.ProjectId == ProjectId && c.EmployeeId == EmployeeId);

                if (project != null)
                {
                    if (employee != null)
                    {
                        if (exist == 0)
                        {

                            var project_emp = new Employee_Project()
                            {
                                ProjectId = ProjectId,
                                EmployeeId = EmployeeId

                            };
                            await _context.Employee_Projects.AddAsync(project_emp);
                            await _context.SaveChangesAsync();
                            ProjectDateUpdated(project_emp.ProjectId);
                        }
                        else
                        {
                            response.Message = "This employee is already added to this project";
                        }
                    }
                    else
                    {
                        response.Message = "Employee not found";
                    }
                }
                else
                {
                    response.Message = "Project not found";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;

        }

        public Task AddNewEmployee(int EmployeeId, AddEmplyeeToProjectVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> AddNewProjectAsync(NewProjectVM data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {

                var newProject = new Project()
                {
                    Name = data.Name,
                    DateCreated = DateTime.Now
                };
                await _context.Projects.AddAsync(newProject);
                await _context.SaveChangesAsync();

                foreach (var employeeId in data.EmployeesIds)
                {
                    var project_emp = new Employee_Project()
                    {
                        ProjectId = newProject.Id,
                        EmployeeId = employeeId,
                    };

                    await _context.Employee_Projects.AddAsync(project_emp);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        [HttpGet]
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = _context.Projects
           .Include(c => c.Employees)
           .Include(p => p.Tasks)
           .FirstOrDefault(n => n.Id == id);
            return project;
        }

        public async Task<NewProjectDropdownsVM> GetProjectDropdownsValues()
        {
            var result = new NewProjectDropdownsVM()
            {
                Employee = await _context.Users.OrderBy(n => n.Name).ToListAsync()

            };
            return result;
        }


        public async Task<ServiceResponse<string>> UpdateProjectAsync(int id, EditProject data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var dbProject = await _context.Projects.FirstOrDefaultAsync(n => n.Id == id);



                if (dbProject != null)
                {
                    var existingProjectName = await _context.Projects.CountAsync(n => n.Name == data.Name);
                    if (existingProjectName == 0)
                    {
                        if (data.Name != dbProject.Name)
                        {
                            dbProject.Name = data.Name;
                            dbProject.DateUpdated = DateTime.Now;

                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            response.Message = "Choose another name";
                        }
                    }
                    else
                    {
                        response.Message = "This project name already exists";
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


        public async Task<ServiceResponse<string>> RemoveEmployeeFromProject(int ProjectId, int EmployeeId)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var projectEmp = await _context.Employee_Projects.FirstOrDefaultAsync(n => n.ProjectId == ProjectId && n.EmployeeId == EmployeeId);
                if (projectEmp != null)
                {
                    var data = projectEmp.ProjectId;
                    ProjectDateUpdated(data);
                    _context.Employee_Projects.Remove(projectEmp);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    response.Message = "Not Found";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task ProjectDateUpdated(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(n => n.Id == id);
            project.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceResponse<string>> DeleteProjectAsync(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                if (id != null)
                {
                    var openTasks = await _context.Tasks.CountAsync(t => t.Projectid == id && t.IsCompleted == false);
                    var project = _context.Projects.FirstOrDefault(m => m.Id == id);
                    if (project != null)
                    {
                        if (openTasks == 0)
                        {
                            _context.Projects.Remove(project);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            response.Message = "You cannot remove a project that has open tasks";
                        }
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


        //public async Task UpdateProjectAsync(NewProjectVM data)
        //{
        //    var dbProject = await _context.Projects.FirstOrDefaultAsync(n => n.Id == data.Id);

        //    if (dbProject != null)
        //    {
        //        dbProject.Name = data.Name;
        //        dbProject.DateUpdated = DateTime.Now;

        //        await _context.SaveChangesAsync();
        //    }

        //    //remove existing employees
        //    var existingEmployess = _context.Employee_Projects.Where(n => n.ProjectId == data.Id).ToList();
        //    _context.Employee_Projects.RemoveRange(existingEmployess);
        //    await _context.SaveChangesAsync();

        //    foreach (var employeeId in data.EmployeesIds)
        //    {
        //        var project_emp = new Employee_Project()
        //        {
        //            ProjectId = data.Id,
        //            EmployeeId = employeeId,
        //        };

        //        await _context.Employee_Projects.AddAsync(project_emp);
        //    }
        //    await _context.SaveChangesAsync();
        //}

        //public async Task AddNewEmployee(int projectId, AddEmplyeeToProjectVM data)
        //{


        //}


    }
}
