using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Answer;
using TestEducation.Aplication.Models.Question;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Data;
using TestEducation.Models;
using TestEducation.Service.FileStoreageService;

namespace TestEducation.Service.QuestionAnswerService
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileStoreageService _fileStorageService;
        private readonly IMinioClient _minioClient;

        public QuestionAnswerService(AppDbContext appDbContext, IFileStoreageService fileStorageService, IMinioClient minioClient)
        {
            _appDbContext = appDbContext;
            _fileStorageService = fileStorageService;
            _minioClient = minioClient;
        }
        public async Task<CreateQuestionAnswerResponseModel> CreateQuestionAnswer(CreateQuestionModel questionDTO)
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

            _appDbContext.Question.Add(question);
            await _appDbContext.SaveChangesAsync();

            return new CreateQuestionAnswerResponseModel
            {
                Id = question.Id,
            };

        }
        public async Task<List<QuestionAnswerResponseModel>> GetAllQuestionAnswer()
        {
            var question = await _appDbContext.Question
                .Include(a => a.AnswerOptions)
                .Select(x => new QuestionAnswerResponseModel
                {
                    QuestionText = x.QuestionText,
                    Image = x.ImageUrl,
                    QuestionLevel = x.Level,
                    Answers = x.AnswerOptions.
                    Select(n => new AnswerGetAllDTO
                    {
                        AnswerText = n.AnswerText,
                    }).ToList()

                }).ToListAsync();

            return question;
        }
        public async Task<QuestionAnswerResponseModel> GetByIdQuestionAnswer(int Id)
        {
            var question = await _appDbContext.Question
                  .Include(a => a.AnswerOptions)
                  .Select(x => new QuestionAnswerResponseModel
                  {
                      QuestionText = x.QuestionText,
                      Image = x.ImageUrl,
                      QuestionLevel = x.Level,
                      Answers = x.AnswerOptions.
                      Select(n => new AnswerGetAllDTO
                      {
                          AnswerText = n.AnswerText,
                      }).ToList()

                  }).FirstOrDefaultAsync();

            if (question == null)
                throw new NotFoundException("Question topilmadi.");

            return question;

        }
        public async Task<UpdateQuestionAnswerResponseModel> UpdateQuestionAnswer(int id, UpdateQuestionAnswerModel questionUpdateDTO)
        {

            string? urlImage = null;

            if (questionUpdateDTO.Image != null && questionUpdateDTO.Image.Length > 0)
            {
                var extension = Path.GetExtension(questionUpdateDTO.Image.FileName);
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
                using var mystream = questionUpdateDTO.Image.OpenReadStream();
                urlImage = await _fileStorageService.UploadFileAsync(
                    "questions-image",
                    objectName,
                    mystream,
                    questionUpdateDTO.Image.ContentType
                );
            }

            var question = await _appDbContext.Question
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (question == null)
                throw new NotFoundException("Question topilmadi.");

            question.QuestionText = questionUpdateDTO.QuestionText;
            question.ImageUrl = urlImage;
            question.AnswerOptions = questionUpdateDTO.Answers
                .Select(x => new Answer
                {
                    AnswerText = x.Text,
                    IsCorrect = x.IsCorrect
                }).ToList();


            await _appDbContext.SaveChangesAsync();

            return new UpdateQuestionAnswerResponseModel { Id = question.Id };
        }
        public async Task<string> DeleteQuestionAnswer(int Id)
        {
            var question = await _appDbContext.Question
                .Include(a => a.AnswerOptions)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (question == null)
                throw new NotFoundException("Question topilmadi.");

            // Avval Answer’larni o‘chiramiz
            _appDbContext.Answers.RemoveRange(question.AnswerOptions);

            // Keyin Questionni o‘chiramiz
            _appDbContext.Question.Remove(question);

            await _appDbContext.SaveChangesAsync();

            return "Question o'chirildi";
        }
        public async Task<Stream> DownloadFileAsyncQuestion(string objectName)
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
        public async Task<PaginationResult<QuestionAnswerResponseModel>> CreateQuestionAnswerPage(QuesstionAnswerPageModel model)
        {
            var query = _appDbContext.Question.AsQueryable();

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(s => s.QuestionText.Contains(model.Search));
            }
            Console.WriteLine(query.ToQueryString());
            List<QuestionAnswerResponseModel> questions = await query
                .Skip(model.PageSize * (model.PageNumber - 1))
                .Take(model.PageSize)
                .Select(x => new QuestionAnswerResponseModel
                {
                    QuestionText = x.QuestionText,
                    Image = x.ImageUrl,
                    QuestionLevel = x.Level,
                    Answers = x.AnswerOptions.
                    Select(n => new AnswerGetAllDTO
                    {
                        AnswerText = n.AnswerText,
                    }).ToList()
                }).ToListAsync();



            int total = _appDbContext.Question.Count();

            return new PaginationResult<QuestionAnswerResponseModel>
            {
                Values = questions,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                TotalCount = total
            };
        }
    }
}
