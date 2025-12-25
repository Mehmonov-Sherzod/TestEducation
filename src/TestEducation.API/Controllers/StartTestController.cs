using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.StartTestMixed;
using TestEducation.Aplication.Models.TestProcsess;
using TestEducation.Aplication.Service;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StartTestController : ControllerBase
    {
        private readonly IStartTestService _startTestService;

        public StartTestController(IStartTestService startTestService)  
        {
            _startTestService = startTestService;
        }

        [Authorize]
        [HttpPost("start-test-mixed30")]
        public async Task<IActionResult> StartTestMixed30(StartTestMixedModels StartTestMixedModels)
        {
            var result = await _startTestService.StartTestMixed30(StartTestMixedModels);

            return Ok(ApiResult<TestProcessResponce>.Success(result));  
        }
    }
}
