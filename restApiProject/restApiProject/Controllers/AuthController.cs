using ClassLibraryModels;
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

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
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


    }

}
