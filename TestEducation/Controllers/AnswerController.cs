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
    public class AnswerController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public AnswerController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        [HttpPost]
        public IActionResult AnswerCreate(AnswerOptionDto answerOptionDto)
        {
            if (answerOptionDto == null)
                NotFound("bosh");

            var Answer = new AnswerOption
            {
                AnswerText = answerOptionDto.Text,
                IsCorrect = answerOptionDto.IsCorrect,
                QuestionId = answerOptionDto.QuestionId,    
            };

            return Ok("Answer yaratildi");
        }

        [HttpGet]
        public IActionResult GetAllAnswer()
        {
            var answer = appDbContext.Answers.
                Select(a => new AnswerOptionDto
                {
                    Text = a.AnswerText,
                    IsCorrect = a.IsCorrect,

                }).ToList();

            return Ok(answer);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Answer = appDbContext.Answers
                .Where(p => p.Id == id)
                .Select(p => new AnswerOptionDto
                {
                    Text = p.AnswerText,
                    IsCorrect = p.IsCorrect,
                })
                .FirstOrDefault();

            if (Answer == null)
                return NotFound("bunday id mavjud emas");

            return Ok(Answer);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateAnswer(int id , AnswerOptionDto answerOptionDto )
        {
            var answer = appDbContext.Answers
                .FirstOrDefault(x => x.Id == id);

            if (answer == null)
                return NotFound("bunday id mavjud emas");

            answer.AnswerText = answerOptionDto.Text;
            answer.IsCorrect = answerOptionDto.IsCorrect;

            appDbContext.SaveChanges();

            return Ok("Malumot o'zgardi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var answer = appDbContext.Answers
                .FirstOrDefault(p =>  p.Id == id);
            
            if (answer == null)
                return NotFound("bunday id mavjud emas");

            appDbContext.Answers.Remove(answer);
            appDbContext.SaveChanges();

            return Ok("malumot ochirildi");
        }
    }
}
