using ClassLibraryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Repositories;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IWebHostEnvironment webHostEnvironment;


        public AuthController(IAuthRepository authRepository, IWebHostEnvironment webHostEnvironment)
        {
            _authRepository = authRepository;
            this.webHostEnvironment = webHostEnvironment;
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


        [HttpPost("registerEmployee"), Authorize(Roles = "Administrator")]
        //
        public async Task<ActionResult<ServiceResponse<int>>> Register([FromForm] RegisterVM request)
        {
            string uniqueFileName = _authRepository.UploadedFile(request.ProfileImage);

            User emp = new User()
            {
                Name = request.Name,
                Lastname = request.LastName,
                Username = request.Username,
                EmailAddress = request.EmailAddress,
                Role = "Employee",
                ImageUrl = uniqueFileName,
            };

            var response = await _authRepository.Register(emp, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        //public void uploadFile([FromForm] IFormFile ProfileImage)
        //{
        //    try
        //    {
        //        string path = webHostEnvironment.WebRootPath + "\\uploads\\";
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        using (FileStream fileStream = System.IO.File.Create(path + ProfileImage.FileName))
        //        {
        //            ProfileImage.CopyTo(fileStream);
        //            fileStream.Flush();

        //        }
        //    }
        //    catch (Exception e) { }

        //}


        [HttpPut("EditEmployee"), Authorize]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateUserAsync(int userId, [FromForm] RegisterVM data)
        {

            //var employee = await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);

            var response = await _authRepository.UpdateUserAsync(userId, data);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("DeleteEmployee {id}"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<string>>> RemoveUserAsync(int id)
        {
            var response = await _authRepository.DeleteUser(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



        //public string UploadedFile([FromForm] IFormFile ProfileImage)
        //{
        //    string uniqueFileName = null;

        //    if (ProfileImage != null)
        //    {
        //        //var appDataPath = Server.MapPath("~/App_Data/");
        //        webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath);
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + ProfileImage.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            ProfileImage.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}


        [HttpGet("Get User Id"), Authorize]
        public int GetUserName()
        {
            var result = _authRepository.GetUserId();

            return result;
        }
    }

}
