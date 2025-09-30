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
            var rezult = await _IsubjectServise.CreateSubject(subjectDTO);
            return Ok(rezult);

        }

        //[HttpPost]
        //public ActionResult Post([FromBody] Subject subject)
        //{

        //}

    }
}
