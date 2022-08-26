using ClassLibraryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Services;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[Controller]")]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;

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


        [HttpPost("EditProject")]
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

        [HttpPost("DeleteProject")]
        public async Task<ServiceResponse<bool>> DeleteConfirmed(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            var project = await _service.GetByIdAsync(id);
            if (project == null)
                response.Success = false;
            return response;
            await _service.DeleteAsync(id);

            return response;

        }
    }
}
