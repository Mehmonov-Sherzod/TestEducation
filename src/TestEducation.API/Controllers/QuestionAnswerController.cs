using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models.Question;
using TestEducation.Service.FileStoreageService;
using TestEducation.Service.QuestionAnswerService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionAnswerController : ControllerBase
    {
        private readonly IQuestionAnswerService _questionAnswerService;
        private readonly IFileStoreageService _fileStoreageService;
        public QuestionAnswerController(IQuestionAnswerService questionAnswerService, IFileStoreageService fileStorageService)
        {
            _questionAnswerService = questionAnswerService;
            _fileStoreageService = fileStorageService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateQuestionAnswer([FromForm] CreateQuestionModel 
            
            
            questionDTO)
        {
            return Ok(await _questionAnswerService.CreateQuestionAnswer(questionDTO));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionAnswer()
        {
            return Ok(await _questionAnswerService.GetAllQuestionAnswer());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdQuestionAnswer(int id)
        {
            return Ok(await _questionAnswerService.GetByIdQuestionAnswer(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionAnswer(int id, UpdateQuestionAnswerModel questionUpdateDTO)
        {
            return Ok(await _questionAnswerService.UpdateQuestionAnswer(id, questionUpdateDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer(int id)
        {
            return Ok(await _questionAnswerService.DeleteQuestionAnswer(id));
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFileQuestionsAnswer([FromQuery] string objectName)
        {
            if (string.IsNullOrEmpty("questions-image") || string.IsNullOrEmpty(objectName))
            {
                return BadRequest("Bucket nomi va obyekt nomi talab qilinadi.");
            }

            try
            {
                var stream = await _fileStoreageService.DownloadFileAsync("questions-image", objectName);
                // Content-Type ni aniqlashga harakat qilish yoki universal qiymat berish
                var contentType = "application/octet-stream"; // Fayl turi noma'lum bo'lsa
                                                              // Agar siz fayl turini saqlagan bo'lsangiz, uni bazadan olib foydalansangiz yaxshi bo'ladi
                return File(stream, contentType, objectName); // Faylni brauzerga jo'natish
            }
            catch (Minio.Exceptions.MinioException e) when (e.Message.Contains("Object does not exist"))
            {
                return NotFound("Fayl topilmadi.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Faylni yuklab olishda kutilmagan xatolik yuz berdi.");
            }
        }
    }
}
