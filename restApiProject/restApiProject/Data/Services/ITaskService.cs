using ClassLibraryModels;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public interface ITaskService : IEntityBaseRepository<Taskk>
    {
        Task<ServiceResponse<string>> MarkTaskAsCompleted(int id);
        Task<ServiceResponse<string>> AddTaskAsync(NewTaskVM data);
        Task<ServiceResponse<string>> Employee_CreateTask(EmployeeNewTask data);
    }
}
