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

        [HttpPost]
        public async Task<IActionResult> CreateSubject(CreateSubjectModel subjectDTO)
        {
            var result = await _IsubjectServise.CreateSubject(subjectDTO);

            return Ok(ApiResult<CreateSubjectResponseModel>.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            var result = await _IsubjectServise.GetaAllSubjects();

            return Ok(ApiResult<List<SubjectResponsModel>>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSubject(int id)
        {
            var result = await _IsubjectServise.GetByIdSubject(id);

            return Ok(ApiResult<SubjectResponsModel>.Success(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int Id, UpdateSubjectModel subjectDTO)
        {
            var result = await _IsubjectServise.UpdateSubject(Id , subjectDTO);

            return Ok(ApiResult<UpdateSubjectResponseModel>.Success(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int Id)
        {
            var result = await _IsubjectServise.DeleteSubject(Id);

            return Ok(ApiResult<string>.Success(result));
        }

        [HttpPost("get-all-page")]
        public async Task<IActionResult> GetAllPage(PageOption model)
        {
            var result = await _IsubjectServise.CreateSubjectPage(model);     

            return Ok(ApiResult<PaginationResult<SubjectResponsModel>>.Success(result));
        }
    }
}
