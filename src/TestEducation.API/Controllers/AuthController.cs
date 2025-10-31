using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
using TestEducation.Service.UserService;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser(CreateUserModel userDTO)
        {
            var result = await _userService.CreateUser(userDTO);

            return Ok(ApiResult<CreateUserResponseModel>.Success(result));

        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUserModel loginUserModel)
        {
            var result = await _userService.LoginAsync(loginUserModel);

            return Ok(ApiResult<LoginResponseModel>.Success(result));
        }

    }
}
