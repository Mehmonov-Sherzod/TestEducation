using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Domain.Enums;
using TestEducation.Filter;
using TestEducation.Service.SubjectService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        public readonly ISubjectServise _IsubjectServise;
        public SubjectController(ISubjectServise IsubjectServise)
        {
            _IsubjectServise = IsubjectServise;
        }

        [RequirePermission(PermissionEnum.ManageSubjects)]
        [HttpPost]
        public async Task<IActionResult> CreateSubject(CreateSubjectModel subjectDTO)
        {
            var result = await _IsubjectServise.CreateSubject(subjectDTO);

            return Ok(ApiResult<CreateSubjectResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSubject(
            [FromRoute] int id,
            [FromHeader] string lang)
        {
            var result = await _IsubjectServise.GetByIdSubject(id, lang);

            return Ok(ApiResult<SubjectResponsModel>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageSubjects)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int Id, UpdateSubjectModel subjectDTO)
        {
            var result = await _IsubjectServise.UpdateSubject(Id, subjectDTO);

            return Ok(ApiResult<UpdateSubjectResponseModel>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageSubjects)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _IsubjectServise.DeleteSubject(id);

            return Ok(ApiResult<string>.Success(result));
        }

        [Authorize]
        [HttpPost("get-all-page")]
        public async Task<IActionResult> GetAllPage(PageOption model, string lang)
        {
            var result = await _IsubjectServise.CreateSubjectPage(model, lang);

            return Ok(ApiResult<PaginationResult<SubjectResponsModel>>.Success(result));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromHeader] string lang)
        {
            var result = await _IsubjectServise.GetAllSubjects(lang);

            return Ok(ApiResult<List<SubjectResponsModel>>.Success(result));
        }
    }
}
