using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;
using TestEducation.Service;

namespace TestEducation.Controllers.AuthService
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase 
    {
        private readonly JwtService jwtService;

        private readonly AppDbContext appDbContext;

        private readonly PasswordHelper passwordHelper;

        public AuthController(JwtService _jwtService, AppDbContext _appDbContext, PasswordHelper _passwordHelper )
        {
            jwtService = _jwtService;
            appDbContext = _appDbContext;
            passwordHelper = _passwordHelper;
        }


        [HttpPost("Register")]

        public IActionResult UserCreate(UserDTO userDto)
        {
            if (userDto == null)
                NotFound("hato");

            string salt = Guid.NewGuid().ToString();

            var hashPass = passwordHelper.Incrypt(userDto.Password, salt);

            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Salt = salt,
                Password = hashPass,
                CreatedAt = DateTime.UtcNow,
            };

            appDbContext.users.Add(user);   

            appDbContext.SaveChanges();

            return Ok("user qo'shildi");

        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto )
        {

            var user = appDbContext.users
                .FirstOrDefault(u => u.Email == loginDto.Email);

            if (user == null)
                return NotFound("User topilmadi");


            //if (!passwordHelper.Verify(loginDto.Password, user.Salt, user.Password))
            //    return BadRequest("Email or Password not correct");


            string token = jwtService.GenerateToken(user);

            return Ok(token);
        }



    }
}
