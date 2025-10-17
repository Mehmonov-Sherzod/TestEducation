using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
using TestEducation.Service.UserService;

namespace TestEducation.Controllers
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

        [HttpPost("User-Create")]
        public async Task<IActionResult> CreateUser(CreateUserModel userDTO)
        {
            var result = await _userService.CreateUser(userDTO);

            return Ok(ApiResult<CreateUserResponseModel>.Success(result));

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

