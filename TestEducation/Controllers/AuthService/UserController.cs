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
            if (userDTO == null)
                return BadRequest("Bunday emailga ega user mavjud");

            var user = await  _userService.CreateUser(userDTO);

            return Ok("user qoshildi");      

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
            if (user == null)
                return BadRequest("bunday id ga ega user mavjud emas");

            return Ok(user);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await _userService.UpdateUser(id, userDTO);

            if (user == null)
                return BadRequest("bunday id ga ega user mavjud emas");

            return Ok(user);
        }
    }
}
