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
            var level = await _questionLevelService.CreateQuestionLevel(questionLevelDTO);

            if (level.IsSuccess)
                return Ok(level.Message);

            else
                return BadRequest(level.Message);                 
        }
    }
}
