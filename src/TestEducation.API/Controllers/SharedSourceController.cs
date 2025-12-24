using Microsoft.AspNetCore.Authorization;
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

        [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
        [RequirePermission(PermissionEnum.ManageAdmins)]
        [HttpPost("create-source")]
        public async Task<IActionResult> CreateShareSource(CreateSharedSource createSharedSource)
        {
            var result = await _sharedSourceService.CreateSharedSource(createSharedSource);

            return Ok(ApiResult<CreateSharedSourceResponseModel>.Success(result));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetAllPageSourceBook(PageOption pageOption , Guid SubjectId)
        {
            var result = await _sharedSourceService.GetAllPageSource(pageOption, SubjectId);

            return Ok(ApiResult<PaginationResult<SharedSourceResponse>>.Success(result));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSource(Guid id)
        {
            var result = await _sharedSourceService.DeleteSourse(id);

            return Ok(ApiResult<string>.Success(result));
        }
    }
}
