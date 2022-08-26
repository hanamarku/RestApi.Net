using ClassLibraryModels;
using Microsoft.EntityFrameworkCore;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public class ProjectService : EntityBaseRepository<Project>, IProjectService
    {
        private readonly AppDbContext _context;
        public ProjectService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProjectAsync(NewProjectVM data)
        {
            var newProject = new Project()
            {
                Name = data.Name,
                DateCreated = DateTime.Now
            };
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            foreach (var employeeId in data.EmployeesIds)
            {
                var project_emp = new Employee_Project()
                {
                    ProjectId = newProject.Id,
                    EmployeeId = employeeId,
                };

                await _context.Employee_Projects.AddAsync(project_emp);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = _context.Projects
           .Include(c => c.Employees)
           .Include(p => p.Tasks)
           .FirstOrDefault(n => n.Id == id);
            return project;
        }

        public async Task<NewProjectDropdownsVM> GetProjectDropdownsValues()
        {
            var result = new NewProjectDropdownsVM()
            {
                Employee = await _context.Employees.OrderBy(n => n.Name).ToListAsync()

            };
            return result;
        }

        public async Task UpdateProjectAsync(NewProjectVM data)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProject != null)
            {
                dbProject.Name = data.Name;
                dbProject.DateUpdated = DateTime.Now;

                await _context.SaveChangesAsync();
            }

            //remove existing characters
            var existingEmployess = _context.Employee_Projects.Where(n => n.ProjectId == data.Id).ToList();
            _context.Employee_Projects.RemoveRange(existingEmployess);
            await _context.SaveChangesAsync();

            foreach (var employeeId in data.EmployeesIds)
            {
                var project_emp = new Employee_Project()
                {
                    ProjectId = data.Id,
                    EmployeeId = employeeId,
                };

                await _context.Employee_Projects.AddAsync(project_emp);
            }
            await _context.SaveChangesAsync();
        }
    }
}
