using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.SharedSource;
using TestEducation.Aplication.Service;
using TestEducation.Domain.Enums;
using TestEducation.Filter;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SharedSourceController : ControllerBase
    {
        private readonly ISharedSourceService _sharedSourceService;

        public SharedSourceController(ISharedSourceService sharedSourceService)
        {
            _sharedSourceService = sharedSourceService;
        }

        [RequirePermission(PermissionEnum.ManageAdmins)]
        [HttpPost("create-source")]
        public async Task<IActionResult> CreateShareSource(CreateSharedSource createSharedSource)
        {
            var result = await _sharedSourceService.CreateSharedSource(createSharedSource);

            return Ok(ApiResult<CreateSharedSourceResponseModel>.Success(result));
        }

    }
}
