using Microsoft.AspNetCore.Mvc;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;
using TestEducation.Service;
using TestEducation.Service.SubjectService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase 
    {


        public readonly ISubjectServise _IsubjectServise;
        public SubjectController( ISubjectServise IsubjectServise )
        {      
      
            _IsubjectServise = IsubjectServise; 
           
        }

        [HttpPost]

        public async Task<IActionResult> CreateSubject(SubjectDto subjectDto)
        {
            var rezult = await _IsubjectServise.CreateSubject(subjectDto);

            return Ok(rezult);


        
        }
    }
}
