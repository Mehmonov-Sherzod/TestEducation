using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public TestController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        [HttpPost]
        public IActionResult TestCreate(TestDto testDto)
        {
            if (testDto == null)
                NotFound("bosh");

            var Test = new Test
            {
                Name = testDto.Name,
                subjectId = testDto.subjectId,
                Description = testDto.Description,

            };
            return Ok("test yaratildi");
        }
        [HttpGet]
        public IActionResult GetAllTest()
        {

            var test = appDbContext.tests
            .Select(p => new TestDto
            {
                Name = p.Name,
            })
            .ToList();

            return Ok(test);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var test = appDbContext.tests
                .Where(p => p.Id == id)
                .Select(p => new TestDto
                {
                    Name = p.Name,
                }).FirstOrDefault();

            if (test == null)
                return NotFound("bunday id mavjud emas");

            return Ok(test);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id, TestDto testDto)
        {
            var test = appDbContext.tests.
                FirstOrDefault(p => p.Id == id);

            if (test == null)
                return NotFound("bunday id mavjud emas");

            test.Name = testDto.Name;

            appDbContext.SaveChanges();

            return Ok(test);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var test = appDbContext.tests
                .FirstOrDefault(p => p.Id == id);

            if (test == null)
                return NotFound("bunday id mavjud emas");

            appDbContext.tests.Remove(test);
            appDbContext.SaveChanges();

            return Ok("malumot ochirildi");
        }
    }
}
