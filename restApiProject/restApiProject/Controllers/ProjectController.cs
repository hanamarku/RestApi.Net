using ClassLibraryModels;
using Microsoft.AspNetCore.Authorization;
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

        public ProjectController(IProjectService service)
        {
            _service = service;
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


        [HttpPost("CreateProject"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<bool>>> Create(NewProjectVM project)
        {


            if (!ModelState.IsValid)
            {
                var employeeDropdownData = await _service.GetProjectDropdownsValues();
                //ViewBag.Employees = new SelectList(employeeDropdownData.Employee, "Id", "Username");
            }
            var response = await _service.AddNewProjectAsync(project);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPut("EditProject"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<string>>> Edit(int id, EditProject project)
        {
            var response = await _service.UpdateProjectAsync(id, project);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }




        [HttpDelete("DeleteProject"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteConfirmed(int id)
        {
            var response = await _service.DeleteProjectAsync(id);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }



        [HttpGet("ProjectDetails"), Authorize(Roles = "Administrator")]

        public async Task<ActionResult<ServiceResponse<Project>>> Details(int id)
        {
            var projectDetails = await _service.GetProjectByIdAsync(id);
            ServiceResponse<Project> response = new ServiceResponse<Project>();
            response.Data = projectDetails;
            return response;
        }


        [HttpDelete("Remove Employee From Project{ProjectId}/{EmployeeId}"), Authorize(Roles = "Administrator")]

        public async Task<ActionResult<ServiceResponse<string>>> RemoveEmployeeFromProject(int ProjectId, int EmployeeId)
        {
            var response = await _service.RemoveEmployeeFromProject(ProjectId, EmployeeId);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("AddEmployeeToProject {ProjectId} {EmployeeId}"), Authorize(Roles = "Administrator")]

        public async Task<ActionResult<ServiceResponse<string>>> AddEmployeeToProject(int ProjectId, int EmployeeId)
        {
            var response = await _service.AddEmployeeToProject(ProjectId, EmployeeId);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
