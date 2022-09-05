using ClassLibraryModels;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Repositories
{
    public interface IAuthRepository : IEntityBaseRepository<User>
    {
        public User GetUser(LoginVM loginVM);
        Task<ServiceResponse<int>> Register(User employee, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<string>> UpdateUserAsync(EditUser data);
        Task<ServiceResponse<string>> DeleteUser(int id);
    }
}
