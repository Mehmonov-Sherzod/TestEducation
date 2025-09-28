using Microsoft.AspNetCore.Mvc;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;
using TestEducation.Service;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase 
    {
        private readonly AppDbContext appDbContext;

        public SubjectController( AppDbContext _appDbContext)
        {
          
            appDbContext = _appDbContext;
        }

        [HttpPost]

        public IActionResult SubjectCreate(SubjectDto subjectDto)
        {

            if (subjectDto  == null)
            {
                NotFound("hato");
            }

            var Subject = new Subject
            {
                Name = subjectDto.Name
            };

           appDbContext.subjects.Add(Subject);
           appDbContext.SaveChanges();

            return Ok("Subject Qoshildi");

        }

    }
}
