using ClassLibraryModels;
using Microsoft.EntityFrameworkCore;
using restApiProject.Data.ViewModels;

namespace restApiProject.Data.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly AppDbContext _context;

        public EmployeeProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<string>> AddEmployeeToProjectAsync(AddEmplyeeToProjectVM data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var project = await _context.Projects.Include(c => c).SingleOrDefaultAsync(c => c.Id == data.ProjectId);

                if (project == null)
                {
                    response.Success = false;
                    response.Message = "Project not found";
                }
                Employee_Project ep = new Employee_Project()
                {
                    ProjectId = data.ProjectId,
                    EmployeeId = data.EmployeeId
                };
                //Employee_Project employee_Project = _context.Employee_Projects.First(c => c.EmployeeId == Eid);
                _context.Employee_Projects.Add(ep);
                await _context.SaveChangesAsync();
                //response.Data = _context.Employee_Projects.Select(c => c.ProjectId == id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> DeletEmployeeAsync(int Eid, int Pid)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Employee_Project employee_Project = _context.Employee_Projects.First(c => c.EmployeeId == Eid && c.ProjectId == Pid);
                _context.Employee_Projects.Remove(employee_Project);
                await _context.SaveChangesAsync();
                //response.Data = _context.Employee_Projects.Select(c => c.ProjectId == id);
            }
            catch (Exception ex)
            {
                //response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
