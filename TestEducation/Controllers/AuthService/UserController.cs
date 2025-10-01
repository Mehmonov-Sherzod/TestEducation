using System.Security.AccessControl;
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
            var result = await _userService.CreateUser(userDTO);

            if (result.IsSuccess)
                return Ok(result);     
            else
                return BadRequest(result); 

        }

        [HttpGet("User-GetAll")]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdUser(int id)
        {      
            var user = await _userService.GetByIdUser(id);
            if (!user.IsSuccess)
                return BadRequest(user.Message);

            return Ok(user);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await _userService.UpdateUser(id, userDTO);

            if (!user.IsSuccess)
                return BadRequest(user.Message);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteByIdUser(id);

            if (!user.IsSuccess)
                return NotFound(user.Message);

            return Ok(user.Message);
        }
    }
}
