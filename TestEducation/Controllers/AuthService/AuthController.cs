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

        public AuthController(JwtService _jwtService, AppDbContext _appDbContext )
        {
            jwtService = _jwtService;
            appDbContext = _appDbContext;
        }


        [HttpPost("Regist")]

        public IActionResult UserCreate(UserDTO userDto)
        {
            if (userDto == null)
                NotFound("hato");
            

            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Password = userDto.Password,
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
                return NotFound("Email  noto‘g‘ri");


            string token = jwtService.GenerateToken(user);

            return Ok(token);
        }



    }
}
