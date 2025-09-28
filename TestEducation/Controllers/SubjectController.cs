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

        [HttpGet]

        public IActionResult GetAll()
        {
            var Subject = appDbContext.subjects.
                Select(S => new SubjectDto
                {
                    Name = S.Name
                }).ToList();

            return Ok(Subject);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = appDbContext.subjects
                .Where(s => s.Id == id)
                .Select(s => new SubjectDto
                {
                    Name = s.Name
                }).FirstOrDefault();

            if (subject == null)
                return NotFound("bunday id mavjud emas");

            return Ok(subject);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateSubject(int id, SubjectDto subjectDto)
        {
            var subject = appDbContext.subjects
                .FirstOrDefault(s => s.Id == id);

            if (subject == null) 
                return NotFound("bunday id mavjud emas");

            subject.Name = subjectDto.Name;

            appDbContext.SaveChanges();

            return Ok(subject);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSubject(int id)
        {
            var subject = appDbContext.subjects.
                FirstOrDefault(s => s.Id == id);

            if (subject == null)
                return NotFound("bunday id mavjud emas");

            appDbContext.subjects.Remove(subject);
            appDbContext.SaveChanges();

            return Ok("malumot ochirildi");
          
        }
    }
}
