using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Repositories;
using restApiProject.Data.Services;

namespace restApiProject.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEmployeeService _service;


        public EmployeeController(IAuthRepository authRepository, IWebHostEnvironment webHostEnvironment, IEmployeeService service)
        {
            _authRepository = authRepository;
            this.webHostEnvironment = webHostEnvironment;
            _service = service;

        }


        [HttpGet("GetAllEmplyees")]

        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<User>> GetSingle(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }






        [HttpPut("EditEmployee")]
        public async Task<ActionResult<ServiceResponse<string>>> Edit(int id, User employee)
        {
            var response = await _service.UpdateAsync(id, employee);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteConfirmed(int id)
        {
            var response = await _service.DeleteAsync(id);
            if (response.Message != "")
            {
                return NotFound(response);
            }
            return Ok(response);

        }




    }
}
