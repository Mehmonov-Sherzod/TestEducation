using Microsoft.AspNetCore.Mvc;
using TestEducation.Dtos;
using TestEducation.Models;
using TestEducation.Service.SubjectService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {

        public readonly ISubjectServise _IsubjectServise;
        public SubjectController(ISubjectServise IsubjectServise)
        {
            _IsubjectServise = IsubjectServise;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectDTO subjectDTO)
        {
            return await _IsubjectServise.CreateSubject(subjectDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            return await _IsubjectServise.GetaAllSubjects();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSubject(int id)
        {
            return await _IsubjectServise.GetByIdSubject(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int Id, SubjectDTO subjectDTO)
        {
            return await _IsubjectServise.UpdateSubject(Id, subjectDTO);    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int Id)
        {
            return await _IsubjectServise.DeleteSubject(Id);
        }
    }
}
