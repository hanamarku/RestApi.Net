using ClassLibraryModels;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public interface IProjectService : IEntityBaseRepository<Project>
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<NewProjectDropdownsVM> GetProjectDropdownsValues();
        Task<ServiceResponse<string>> AddNewProjectAsync(NewProjectVM data);
        Task<ServiceResponse<string>> UpdateProjectAsync(int id, EditProject data);
        Task<ServiceResponse<string>> AddEmployeeToProject(int ProjectId, int EmployeeId);
        Task<ServiceResponse<string>> RemoveEmployeeFromProject(int ProjectId, int EmployeeId);
        Task<ServiceResponse<string>> DeleteProjectAsync(int id);

    }
}
