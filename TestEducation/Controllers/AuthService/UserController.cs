using Microsoft.AspNetCore.Mvc;
using TestEducation.Dtos;
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
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            return await _userService.CreateUser(userDTO);

        }

        [HttpGet("User-GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdUser(int id)
        {
            return await _userService.GetByIdUser(id);    
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            return await  _userService.UpdateUser(id, userDTO);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return await _userService.DeleteByIdUser(id);
        }
    }
}

