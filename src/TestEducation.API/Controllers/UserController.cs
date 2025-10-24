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
        [Authorize]
        //[RequirePermission(PermissionEnum.ManageStudents)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserModel userDTO)
        {
           var result =  await _userService.UpdateUser(id, userDTO);

           return Ok(ApiResult<UpdateUserResponseModel>.Success(result));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteByIdUser(id);

            return Ok(ApiResult<string>.Success(result));
        }

        [HttpPost("get-all-page")]
        public async Task<IActionResult> CreateUserPage(UserPageModel model)
        {
            var result = await _userService.CreateUserPage(model);

            return Ok(ApiResult<PaginationResult<CreateUserModel>>.Success(result));
        }
    }
}

