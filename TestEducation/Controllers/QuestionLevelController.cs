using Microsoft.AspNetCore.Mvc;
using TestEducation.Dtos;
using TestEducation.Service.QuestionLevelService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionLevelController : ControllerBase
    {
        private readonly IQuestionLevelService _questionLevelService;
        
        public QuestionLevelController(IQuestionLevelService questionLevelService)
        {
            _questionLevelService = questionLevelService;
        }

        [HttpPost]

        public async Task<IActionResult> CreateQuestionLevel(QuestionLevelDTO questionLevelDTO)
        {
            return await _questionLevelService.CreateQuestionLevel(questionLevelDTO);             
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionLevel()
        {
            return await _questionLevelService.GetAllQuestionLevel();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdQuestionLevel(int id)
        {
            return await _questionLevelService.GetByIdQuestionLevel(id);
        }
    }
}
