using ClassLibraryModels;

namespace restApiProject.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Employee employee, string password);
        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
