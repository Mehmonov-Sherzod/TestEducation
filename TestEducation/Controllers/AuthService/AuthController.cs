using Microsoft.AspNetCore.Mvc;
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

        public IActionResult UserCreate(UserDto userDto)
        {
            if (userDto == null)
            {
                NotFound("hato");
            }

            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Password = userDto.Password,
                IsActive = userDto.IsActive,
                CreatedAt = DateTime.UtcNow,
            };

            appDbContext.users.Add(user);   

            appDbContext.SaveChanges();

            return Ok("user qo'shildi");

        }



    }
}
