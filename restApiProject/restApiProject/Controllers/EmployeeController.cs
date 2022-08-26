using ClassLibraryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Repositories;
using restApiProject.Data.Services;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    [Authorize(Roles = "Administrator")]
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
            webHostEnvironment = webHostEnvironment;
            _service = service;

        }

        //register usrers

        [HttpPost("registerEmployee")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterVM request)
        {
            string uniqueFileName = UploadedFile(request.ProfileImage);


            var response = await _authRepository.Register(new Employee
            {
                Name = request.Name,
                Lastname = request.LastName,
                Username = request.Username,
                EmailAddress = request.EmailAddress,
                Role = "Employee",
                ImageUrl = uniqueFileName,

            },
            request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPost("EditEmployee")]
        public async Task<ServiceResponse<string>> Edit(int id, Employee employee)
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

        [HttpPost("DeleteEmployee")]
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

        private string UploadedFile(IFormFile ProfileImage)
        {
            string uniqueFileName = null;

            if (ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


    }
}
