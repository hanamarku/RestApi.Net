using ClassLibraryModels;
using restApiProject.Data.BaseRepository;

namespace restApiProject.Data.Services
{
    public class EmployeeService : EntityBaseRepository<Employee>, IEmployeeService
    {
        public EmployeeService(AppDbContext context) : base(context)
        {

        }

    }
}
