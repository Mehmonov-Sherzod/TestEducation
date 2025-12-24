using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
using TestEducation.Aplication.Models.UserSharedSources;
using TestEducation.Aplication.Service;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSharedSourcesController : ControllerBase
    {
        private readonly IUserSharedSourcesService _userSharedSourcesService;

        public UserSharedSourcesController(IUserSharedSourcesService userSharedSourcesService)
        {
            _userSharedSourcesService = userSharedSourcesService;   
        }

        [HttpGet]

        public async Task<IActionResult> GetMyBook()
        {
            var result = await _userSharedSourcesService.GetMySharedSource();

            return Ok(ApiResult<List<UserSharedSourcesResponce>>.Success(result));
        }

    }
}
