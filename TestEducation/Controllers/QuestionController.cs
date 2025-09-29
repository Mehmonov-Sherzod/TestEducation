using Microsoft.AspNetCore.Mvc;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public QuestionController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        [HttpPost]
        public IActionResult CreateQuestion(QuestionDto questionDto)
        {
            if (questionDto == null)
                NotFound("bosh");

            var question = new Question
            {
                QuestionText = questionDto.QuestionText,
                TestId = questionDto.TestId,
                AnswerOptions = questionDto.Answers
                .Select(a => new AnswerOption
                {

                    AnswerText = a.Text,
                    IsCorrect = a.IsCorrect,
                }).ToList()
            };
            appDbContext.question.Add(question);
            appDbContext.SaveChanges();

            return Ok("question Qoshildi");
        }

        [HttpGet]
        public IActionResult GetAllQuestion()
        {
            var question = appDbContext.question
                .Select(q => new QuestionDto
                {
                    QuestionText = q.QuestionText,
                }).ToList();

            return Ok(question);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            var question = appDbContext.question
                .Where(q => q.Id == id)
                .Select(q => new QuestionDto
                {
                    QuestionText = q.QuestionText,
                }).FirstOrDefault();

            if (question == null)
                return NotFound("bunday id mavjud emas");

            return Ok(question);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, QuestionDto questionDto)
        {
            var question = appDbContext.question.
                FirstOrDefault(q => q.Id == id);

            if (question == null)
                return NotFound("bunday id mavjud emas");

            question.QuestionText = questionDto.QuestionText;

            appDbContext.SaveChanges();

            return Ok(question);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var question = appDbContext.question
                .FirstOrDefault(q => q.Id == id);

            if (question == null)
                return NotFound("bunday id mavjud emas");

            appDbContext.question.Remove(question);
            appDbContext.SaveChanges();

            return Ok("malumot ochirildi");
        }

        }
        
    }

