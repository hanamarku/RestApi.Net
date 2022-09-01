using ClassLibraryModels;
using restApiProject.Data.BaseRepository;

namespace restApiProject.Data.Services
{
    public interface ITaskService : IEntityBaseRepository<Taskk>
    {
        Task<ServiceResponse<string>> MarkTaskAsCompleted(int id);
    }
}
