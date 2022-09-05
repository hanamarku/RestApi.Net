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
        Task<ServiceResponse<string>> UpdateTaskAsync(int id, NewTaskVM data);
        Task<ServiceResponse<string>> AddEmployeeToTaskAsync(int taskId, AddTaskToEmployee data);
        Task<ServiceResponse<string>> MarkTaskAsCompletedEmployee(int id);
        Task<List<Employee_Project>> GetProjectsOfEmployee();
        Task<List<Taskk>> GetTasksOfEmployees();
        Task<List<Taskk>> GetTasksProjectOfEmployee(int projectId);


    }
}
