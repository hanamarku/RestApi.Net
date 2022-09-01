using ClassLibraryModels;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public interface IEmployeeProjectService
    {
        Task<ServiceResponse<string>> DeletEmployeeAsync(int Eid, int Pid);

        Task<ServiceResponse<string>> AddEmployeeToProjectAsync(AddEmplyeeToProjectVM addEmplyeeToProjectVM);
    }
}
