using ClassLibraryModels;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User employee, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<string>> UpdateUserAsync(EditUser data);
        Task<ServiceResponse<string>> DeleteUser(int id);
    }
}
