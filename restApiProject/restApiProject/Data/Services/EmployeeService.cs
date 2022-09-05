using ClassLibraryModels;
using restApiProject.Data.BaseRepository;

namespace restApiProject.Data.Services
{
    public class EmployeeService : EntityBaseRepository<User>, IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


    }
}
