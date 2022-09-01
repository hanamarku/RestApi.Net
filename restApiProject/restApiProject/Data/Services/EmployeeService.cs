using ClassLibraryModels;
using restApiProject.Data.BaseRepository;

namespace restApiProject.Data.Services
{
    public class EmployeeService : EntityBaseRepository<User>, IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
