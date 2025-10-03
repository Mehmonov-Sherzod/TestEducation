using Microsoft.AspNetCore.Mvc;
using TestEducation.Dtos;
using TestEducation.Service.QuestionAnswerService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionAnswerController : ControllerBase
    {
        private readonly IQuestionAnswerService _questionAnswerService;
        public QuestionAnswerController(IQuestionAnswerService questionAnswerService)
        {
            _questionAnswerService = questionAnswerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionAnswer(QuestionDTO questionAnswerDTO)
        {
            return await _questionAnswerService.CreateQuestionAnswer(questionAnswerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer(int id)
        {
            return await _questionAnswerService.DeleteQuestionAnswer(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionAnswer()
        {
            return await _questionAnswerService.GetAllQuestionAnswer();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdQuestionAnswer(int id)
        {
            return await _questionAnswerService.GetByIdQuestionAnswer(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionAnswer(int id, QuestionUpdateDTO questionUpdateDTO)
        {
            return await _questionAnswerService.UpdateQuestionAnswer(id, questionUpdateDTO);
        }
    }
}
