using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models.Users;
using TestEducation.Data;
using TestEducation.Models;
using TestEducation.Service;


namespace TestEducation.Controllers.AuthService
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly AppDbContext _appDbContext;
        private readonly PasswordHelper _passwordHelper;

        public AuthController(JwtService jwtService, AppDbContext appDbContext, PasswordHelper passwordHelper)
        {
            _jwtService = jwtService;
            _appDbContext = appDbContext;
            _passwordHelper = passwordHelper;
        }

        [HttpPost("Register")]
        public IActionResult UserCreate(CreateUserModel userDto)
        {
            if (userDto == null)
                NotFound("hato");

            string salt = Guid.NewGuid().ToString();

            var hashPass = _passwordHelper.Incrypt(userDto.Password, salt);

            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Salt = salt,
                Password = hashPass,
                CreatedAt = DateTime.UtcNow,

            };

            _appDbContext.Users.Add(user);

            _appDbContext.SaveChanges();

            return Ok("user qo'shildi");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            var user = _appDbContext.Users
                .FirstOrDefault(u => u.Email == loginDto.Email);

            if (user == null)
                return NotFound("User topilmadi");

            //if (!_passwordHelper.Verify(loginDto.Password, user.Salt, user.Password))
            //    return BadRequest("Email or Password not correct");

            string token = _jwtService.GenerateToken(user);

            return Ok(token);
        }
    }
}
