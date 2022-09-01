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
        public async Task<ServiceResponse<string>> Edit(int id, User employee)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Model state is not valid !";
                return response;
            }

            await _service.UpdateAsync(id, employee);
            response.Message = "Edited Succesfully !";
            return response;

        }

        [HttpDelete("DeleteEmployee")]
        public async Task<ServiceResponse<bool>> DeleteConfirmed(int id)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            var employee = await _service.GetByIdAsync(id);
            if (employee == null)
                response.Success = false;
            return response;
            await _service.DeleteAsync(id);

            return response;

        }




    }
}
