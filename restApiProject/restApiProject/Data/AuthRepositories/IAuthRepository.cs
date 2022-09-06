using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
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
        Task<ServiceResponse<string>> UpdateUserAsync(int userId, RegisterVM data);
        Task<ServiceResponse<string>> DeleteUser(int id);
        public string UploadedFile([FromForm] IFormFile ProfileImage);

    }
}
