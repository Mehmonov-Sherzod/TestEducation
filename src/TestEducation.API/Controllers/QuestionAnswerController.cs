using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Question;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Service.FileStoreageService;
using TestEducation.Service.QuestionAnswerService;
using TestEducation.Service.SubjectService;

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
        public async Task<IActionResult> CreateQuestionAnswer( CreateQuestionModel questionDTO)
        {
            var result = await _questionAnswerService.CreateQuestionAnswer(questionDTO);

            return Ok(ApiResult<CreateQuestionAnswerResponseModel>.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionAnswer()
        {
            var result = await _questionAnswerService.GetAllQuestionAnswer();

            return Ok(ApiResult<List<QuestionAnswerResponseModel>>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdQuestionAnswer(int id)
        {
            var result = await _questionAnswerService.GetByIdQuestionAnswer(id);

            return Ok(ApiResult<QuestionAnswerResponseModel>.Success(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionAnswer(  int id, UpdateQuestionAnswerModel questionUpdateDTO)
        {
            var result = await _questionAnswerService.UpdateQuestionAnswer(id , questionUpdateDTO);

            return Ok(ApiResult<UpdateQuestionAnswerResponseModel>.Success(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer(int id)
        {
            var result = await _questionAnswerService.DeleteQuestionAnswer(id);

            return Ok(ApiResult<string>.Success(result));
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

        [HttpPost("get-all-page")]
        public async Task<IActionResult> GetAllQuestionAnswerPage(QuesstionAnswerPageModel model)
        {
            var result = await _questionAnswerService.CreateQuestionAnswerPage(model);

            return Ok(ApiResult<PaginationResult<QuestionAnswerResponseModel>>.Success(result));

        }
    }
}
