using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Question;
using TestEducation.Domain.Enums;
using TestEducation.Filter;
using TestEducation.Service.FileStoreageService;
using TestEducation.Service.QuestionAnswerService;

namespace TestEducation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionAnswerController : ControllerBase
    {
        private readonly IQuestionAnswerService _questionAnswerService;
        private readonly IFileStoreageService _fileStoreageService;
        public QuestionAnswerController(IQuestionAnswerService questionAnswerService, IFileStoreageService fileStorageService)
        {
            _questionAnswerService = questionAnswerService;
            _fileStoreageService = fileStorageService;
        }

        //[RequirePermission(PermissionEnum.ManageQuestions)]
        [HttpPost]
        public async Task<IActionResult> CreateQuestionAnswer(CreateQuestionModel questionDTO)
        {
            var result = await _questionAnswerService.CreateQuestionAnswer(questionDTO);

            return Ok(ApiResult<CreateQuestionAnswerResponseModel>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageQuestions)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdQuestionAnswer(Guid id, string lang)
        {
            var result = await _questionAnswerService.GetByIdQuestionAnswer(id, lang);

            return Ok(ApiResult<QuestionAnswerResponseModel>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageQuestions)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionAnswer(Guid id, UpdateQuestionAnswerModel questionUpdateDTO)
        {
            var result = await _questionAnswerService.UpdateQuestionAnswer(id, questionUpdateDTO);

            return Ok(ApiResult<UpdateQuestionAnswerResponseModel>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageQuestions)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer(Guid id)
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

        [RequirePermission(PermissionEnum.ManageQuestions)]
        [HttpPost("get-all-page")]
        public async Task<IActionResult> GetAllQuestionAnswerPage(PageOption model, string lang, Guid TopicId, Guid SubjectId)
        {
            var result = await _questionAnswerService.CreateQuestionAnswerPage(model, lang, TopicId, SubjectId );

            return Ok(ApiResult<PaginationResult<QuestionAnswerResponseModel>>.Success(result));

        }
    }
}
