using ClassLibraryModels;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public class TaskService : EntityBaseRepository<Taskk>, ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<string>> AddTaskAsync(NewTaskVM data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
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
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

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
