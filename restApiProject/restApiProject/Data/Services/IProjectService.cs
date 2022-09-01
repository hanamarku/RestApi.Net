using ClassLibraryModels;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public interface IProjectService : IEntityBaseRepository<Project>
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<NewProjectDropdownsVM> GetProjectDropdownsValues();
        Task AddNewProjectAsync(NewProjectVM data);
        Task UpdateProjectAsync(NewProjectVM data);
        Task AddNewEmployee(int projectId, AddEmplyeeToProjectVM data);

    }
}
