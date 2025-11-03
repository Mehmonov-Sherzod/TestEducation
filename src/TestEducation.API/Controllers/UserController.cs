using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
using TestEducation.Domain.Enums;
using TestEducation.Filter;
using TestEducation.Service.UserService;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAdmin(CreateUserByAdminModel createUserByAdminModel)
        {
            var result = await _userService.AdminCreateUserAsync(createUserByAdminModel);

            return Ok(ApiResult<CreateAdminResponseModel>.Success(result));
        }

        [HttpGet("User-GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();

            return Ok(ApiResult<List<UserResponseModel>>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var result = await _userService.GetByIdUser(id);

            return Ok(ApiResult<UserResponseModel>.Success(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserModel userDTO)
        {
            var result = await _userService.UpdateUser(id, userDTO);

            return Ok(ApiResult<UpdateUserResponseModel>.Success(result));

        }

        //[Authorize(Roles = "Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteByIdUser(id);

            return Ok(ApiResult<string>.Success(result));
        }

        [HttpPost("get-all-page")]
        public async Task<IActionResult> CreateUserPage(PageOption model)
        {
            var result = await _userService.CreateUserPage(model);

            return Ok(ApiResult<PaginationResult<CreateUserModel>>.Success(result));
        }

        [HttpGet("{id}-Get-ById-Permission-User")]
        public async Task<IActionResult> GetUserPermission(int id)
        {
            var result = await _userService.GetUserPermission(id);
            return Ok(ApiResult<List<string>>.Success(result));
        }

        [HttpPut("{id}-Update-password")]

        public async Task<IActionResult> UpdateUserPassword(UpdateUserPassword updateUserPassword, int id)
        {
            var result = await _userService.UpdateUserPassword(updateUserPassword, id);

            return Ok(ApiResult<UpdateUserPasswordResponseModel>.Success(result));
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtpAsync([FromBody] OtpVerificationModel model)
        {
            var result = await _userService.VerifyOtpAsync(model);

            return Ok(ApiResult<string>.Success(result));
        }

        [HttpPost("Forgot-Password")]

        public async Task<IActionResult> ForgotPassword(UserEmailForgot userEmailForgot)
        {
            var result = await _userService.ForgotPassword(userEmailForgot);

            return Ok(ApiResult<bool>.Success(result));
        }

        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword(UserEmailReset userEmailReset)
        {
            var result = await _userService.ResetPassword(userEmailReset);

            return Ok(ApiResult<string>.Success(result));
        }
    }
}

