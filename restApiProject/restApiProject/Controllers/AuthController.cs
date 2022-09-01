using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Repositories;
using restApiProject.Data.Services;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEmployeeService _service;

        public AuthController(IAuthRepository authRepository, IWebHostEnvironment webHostEnvironment, IEmployeeService employeeService)
        {
            _authRepository = authRepository;
            this.webHostEnvironment = webHostEnvironment;
            employeeService = _service;
        }


        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginVM request)
        {
            var response = await _authRepository.Login(request.Username, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        //register users

        [HttpPost("registerEmployee")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterVM request)
        {
            //string uniqueFileName = UploadedFile(request.ProfileImage);

            User emp = new User()
            {
                Name = request.Name,
                Lastname = request.LastName,
                Username = request.Username,
                EmailAddress = request.EmailAddress,
                Role = "Employee"
                //ImageUrl = uniqueFileName,
            };

            var response = await _authRepository.Register(emp, request.Password);



            //Name = request.Name,
            //Lastname = request.LastName,
            //Username = request.Username,
            //EmailAddress = request.EmailAddress
            ////Role = "Employee"
            ////ImageUrl = uniqueFileName,



            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPut("EditEmployee")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateUserAsync(EditUser data)
        {
            var response = await _authRepository.UpdateUserAsync(data);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("DeleteEmployee {id}")]
        public async Task<ActionResult<ServiceResponse<string>>> RemoveUserAsync(int id)
        {
            var response = await _authRepository.DeleteUser(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
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
