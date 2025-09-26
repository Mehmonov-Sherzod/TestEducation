using Microsoft.AspNetCore.Mvc;
using TestEducation.Data;
using TestEducation.Dtos;
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


        //[HttpPost("Regist")]

        //public IActionResult UserCreate(UserDto userDto)
        //{
        //    if (userDto == null)
        //    {

        //    }

        //}



    }
}
