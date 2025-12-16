using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.UserEmail;
using TestEducation.Aplication.Models.Users;
using TestEducation.Domain.Enums;
using TestEducation.Filter;
using TestEducation.Service.UserService;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [RequirePermission(PermissionEnum.ManageAdmins)]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAdmin(CreateUserByAdminModel createUserByAdminModel)
        {
            var result = await _userService.AdminCreateUserAsync(createUserByAdminModel);

            return Ok(ApiResult<CreateAdminResponseModel>.Success(result));
        }


        [RequirePermission(PermissionEnum.ManageUsersStudent)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var result = await _userService.GetByIdUser(id);

            return Ok(ApiResult<UserResponseModel>.Success(result));
        }


        [RequirePermission(PermissionEnum.ManageAdmins, PermissionEnum.ManageUsersStudent)]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserModel userDTO)
        {
            var result = await _userService.UpdateUser(userDTO);

            return Ok(ApiResult<UpdateUserResponseModel>.Success(result));

        }


        [RequirePermission(PermissionEnum.ManageAdmins , PermissionEnum.ManageUsersStudent)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteByIdUser(id);

            return Ok(ApiResult<string>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageAdmins , PermissionEnum.ManageUsersStudent)]
        [HttpPost("get-all-page")]
        public async Task<IActionResult> CreateUserPage(PageOption model)
        {
            var result = await _userService.CreateUserPage(model);

            return Ok(ApiResult<PaginationResult<UserResponseModel>>.Success(result));
        }


        [RequirePermission(PermissionEnum.ManageAdmins, PermissionEnum.ManageUsersStudent)]
        [HttpPut("{id}-Update-password")]
        public async Task<IActionResult> ResetPassword(UpdateUserPassword updateUserPassword, int id)
        {
            var result = await _userService.ResetPassword(updateUserPassword);

            return Ok(ApiResult<UpdateUserPasswordResponseModel>.Success(result));
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtpAsync([FromBody] OtpVerificationModel model)
        {
            var result = await _userService.VerifyOtpAsync(model);

            return Ok(ApiResult<string>.Success(result));
        }

        [HttpPost("Send-otp-code")]

        public async Task<IActionResult> ForgotPassword(UserEmailForgot userEmailForgot)
        {
            var result = await _userService.SendOtpByEmail(userEmailForgot);

            return Ok(ApiResult<bool>.Success(result));
        }

        [HttpPost("Forget-Password")]
        public async Task<IActionResult> SendOtp(UserEmailReset userEmailReset)
        {
            var result = await _userService.ForgotPassword(userEmailReset);

            return Ok(ApiResult<string>.Success(result));
        }
    }
}

