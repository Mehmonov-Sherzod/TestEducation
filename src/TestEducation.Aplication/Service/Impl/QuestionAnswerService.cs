using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;
using static System.Net.Mime.MediaTypeNames;
using TestEducation.Service.FileStoreageService;
using Minio.DataModel.Args;
using Minio;
using TestEducation.Aplication.Models.Question;

namespace TestEducation.Service.QuestionAnswerService
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly AppDbContext _appDbContext;

        private readonly IFileStoreageService _fileStorageService;


        private readonly IMinioClient _minioClient;

        public QuestionAnswerService(AppDbContext appDbContext , IFileStoreageService fileStorageService , IMinioClient minioClient)
        {
            _appDbContext = appDbContext;
            _fileStorageService = fileStorageService;
            _minioClient = minioClient;
        }

        public async Task<ResponseDTO> CreateQuestionAnswer( QuestionDTO questionDTO)
        {
            string? urlImage = null;

            if (questionDTO.Image != null && questionDTO.Image.Length > 0)
            {
                var extension = Path.GetExtension(questionDTO.Image.FileName);
                var objectName = $"{Guid.NewGuid()}{extension}";
                //Console.WriteLine("\n" +extension + " " + objectName);
                //Console.WriteLine(questionDTO.Image);
                //using var stream = questionDTO.Image.OpenReadStream();
                //using var ms = new MemoryStream();
                //await stream.CopyToAsync(ms);
                //byte[] results = new byte[stream.Length];
                //results = ms.ToArray();
                //string result = string.Join("", results);
                //Console.Write(result);
                //Console.Write('\n' + result.Length);
                using var mystream = questionDTO.Image.OpenReadStream();
                urlImage = await _fileStorageService.UploadFileAsync(
                    "questions-image",
                    objectName,
                    mystream,
                    questionDTO.Image.ContentType
                );
            }

            var question = new Question
            {
                QuestionText = questionDTO.QuestionText,
                SubjectId = questionDTO.SubjectId,
                ImageUrl = urlImage,
                Level = questionDTO.Level,
                AnswerOptions = questionDTO.Answers
                .Select(a => new Answer
                {
                    AnswerText = a.Text,
                    IsCorrect = a.IsCorrect,
                }).ToList(),

            };

            _appDbContext.question.Add(question);
            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO<QuestionDTO>
            {
                IsSuccess = true,
                Message = "Malumoot qo'shildi",
                StatusCode = 200,
                Data = questionDTO
            };
        }

        public async Task<ResponseDTO> DeleteQuestionAnswer(int Id)
        {
            var question = await _appDbContext.question
                .Include(a => a.AnswerOptions)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (question == null)
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Savol topilmadi",
                    StatusCode = 404
                };

            // Avval Answer’larni o‘chiramiz
            _appDbContext.Answers.RemoveRange(question.AnswerOptions);

            // Keyin Questionni o‘chiramiz
            _appDbContext.question.Remove(question);

            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Savol va uning javoblari o‘chirildi",
                StatusCode = 200
            };
        }

        public async Task<Stream> DownloadFileAsyncQuestion( string objectName)
        {
            var memoryStream1 = new MemoryStream();
            await _minioClient.GetObjectAsync(
                new GetObjectArgs()
                    .WithBucket("questions-image")
                    .WithObject(objectName)
                    .WithCallbackStream(async (stream) => // Fayl streamini memoryStream ga nusxalash
                    {
                        await stream.CopyToAsync(memoryStream1);
                    })
            ).ConfigureAwait(false);

            memoryStream1.Position = 0; // Streamni boshiga qaytarish, chunki undan o'qish mumkin bo'lishi uchun
            return memoryStream1;
        }

        public async Task<ResponseDTO<ICollection<QuestionGetAllDTO>>> GetAllQuestionAnswer()
        {
           
            var question = await _appDbContext.question
                .Include(a => a.AnswerOptions)
                .Select(x => new QuestionGetAllDTO
                {
                    QuestionText = x.QuestionText,
                    Image = x.ImageUrl,
                    Answers = x.AnswerOptions.
                    Select(n => new AnswerGetAllDTO
                    {
                        AnswerText = n.AnswerText,
                    }).ToList()
                }).ToListAsync();

            return new ResponseDTO<ICollection<QuestionGetAllDTO>>
            {
                StatusCode = 200,
                Data = question,
            };           

        }

        public async Task<ResponseDTO<QuestionGetAllDTO>> GetByIdQuestionAnswer(int Id)
        {
            var question = await _appDbContext.question
                .Where(a => a.Id == Id)
                .Include(a => a.AnswerOptions)
                .Select(x => new QuestionGetAllDTO
                {
                    QuestionText = x.QuestionText,
                    Image = x.ImageUrl,
                    Answers = x.AnswerOptions
                    .Select(x => new AnswerGetAllDTO
                    {
                        AnswerText = x.AnswerText,
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (question == null)
                return new ResponseDTO<QuestionGetAllDTO>()
                {
                    Message = "Bunday id ga ega question mavjud emas",
                    StatusCode = 404,
                    Data = question
                };


            return new ResponseDTO<QuestionGetAllDTO>
            {
                StatusCode = 200,
                Data = question,
            };
 
        }

        public async Task<ResponseDTO<QuestionUpdateDTO>> UpdateQuestionAnswer(int id, QuestionUpdateDTO questionUpdateDTO)
        {
           var question = await _appDbContext.question
                .FirstOrDefaultAsync(x =>  x.Id == id); 

            if (question == null)
                return new ResponseDTO<QuestionUpdateDTO>()
                {
                    IsSuccess = false,
                    Message = "bunday id ga ega question mavjud emas",
                    StatusCode = 404,
                    Data = null,
                };

            question.QuestionText = questionUpdateDTO.QuestionText;
            question.AnswerOptions = questionUpdateDTO.Answers.
                Select(x => new Answer
                {
                    AnswerText = x.Text,
                    IsCorrect = x.IsCorrect,
                }).ToList();

            _appDbContext.question.Add(question);
            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO<QuestionUpdateDTO>()
            {
                Message = "Malumot Qo'shildi",
                StatusCode = 200,
                Data = new QuestionUpdateDTO
                {
                    QuestionText = questionUpdateDTO.QuestionText,
                    Answers = questionUpdateDTO.Answers.
                    Select(a => new AnswerDTO
                    {
                        Text = a.Text,
                        IsCorrect = a.IsCorrect,
                    }).ToList()
                },
            };
        }
    }
}
