using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Services;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[Controller]")]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectService _service;
        private readonly IEmployeeProjectService _employeeProjectService;

        public ProjectController(IProjectService service, IEmployeeProjectService employeeProjectService)
        {
            _service = service;
            _employeeProjectService = employeeProjectService;
        }



        [HttpGet("GetAllProjects")]

        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Project>> GetSingle(int id)
        {
            return Ok(await _service.GetProjectByIdAsync(id));
        }


        //Project


        [HttpPost("CreateProject")]
        public async Task<ServiceResponse<bool>> Create(NewProjectVM project)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            if (!ModelState.IsValid)
            {
                var employeeDropdownData = await _service.GetProjectDropdownsValues();
                //ViewBag.Employees = new SelectList(employeeDropdownData.Employee, "Id", "Username");
                response.Success = false;
            }

            await _service.AddNewProjectAsync(project);
            //response.Data = project;
            return response;
        }




        [HttpPut("EditProject")]
        public async Task<ServiceResponse<string>> Edit(int id, NewProjectVM project)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (id != project.Id)
                response.Success = false;
            response.Message = "Not found";
            return response;

            if (!ModelState.IsValid)
            {
                var employeeDropdownData = await _service.GetProjectDropdownsValues();
                //ViewBag.Employees = new SelectList(employeeDropdownData.Employee, "Id", "Username");
                response.Success = false;
            }

            await _service.UpdateProjectAsync(project);
            //response.Data = project;
            response.Message = "Success";
            return response;
        }

        [HttpDelete("DeleteProject")]
        public async Task<ServiceResponse<bool>> DeleteConfirmed(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            var project = await _service.GetByIdAsync(id);
            if (project == null)
                response.Success = false;
            await _service.DeleteAsync(id);

            return response;

        }



        [HttpGet("EmployeeDetails")]

        public async Task<ServiceResponse<Project>> Details(int id)
        {
            var projectDetails = await _service.GetProjectByIdAsync(id);
            ServiceResponse<Project> response = new ServiceResponse<Project>();
            response.Data = projectDetails;
            return response;
        }


        [HttpDelete("{idE}/{idP}")]

        public async Task<ActionResult<ServiceResponse<string>>> RemoveEmployee(int idE, int idP)
        {
            var response = await _employeeProjectService.DeletEmployeeAsync(idE, idP);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("AddEmployeeToProject")]

        public async Task<ActionResult<ServiceResponse<string>>> AddEmployeeToProject(AddEmplyeeToProjectVM data)
        {
            var response = await _employeeProjectService.AddEmployeeToProjectAsync(data);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
