﻿using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Answer;
using TestEducation.Aplication.Models.Question;
using TestEducation.Aplication.Validators.QuestionValidator;
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
        private readonly QuestionCreateValidator _validationRules;

        public QuestionAnswerService(AppDbContext appDbContext, IFileStoreageService fileStorageService, IMinioClient minioClient, QuestionCreateValidator validationRules)
        {
            _appDbContext = appDbContext;
            _fileStorageService = fileStorageService;
            _minioClient = minioClient;
            _validationRules = validationRules;

        }
        public async Task<CreateQuestionAnswerResponseModel> CreateQuestionAnswer(CreateQuestionModel questionDTO)
        {
            //string? urlImage = null;

            //if (questionDTO.Image != null && questionDTO.Image.Length > 0)
            //{
            //    var extension = Path.GetExtension(questionDTO.Image.FileName);
            //    var objectName = $"{Guid.NewGuid()}{extension}";
            //    using var mystream = questionDTO.Image.OpenReadStream();
            //    urlImage = await _fileStorageService.UploadFileAsync(
            //        "questions-image",
            //        objectName,
            //        mystream,
            //        questionDTO.Image.ContentType
            //    );
            //}

            var result = _validationRules.Validate(questionDTO);

            Question question = new Question
            {
                QuestionText = questionDTO.QuestionText,
                SubjectId = questionDTO.SubjectId,
                //ImageUrl = urlImage,
                Level = questionDTO.Level,
                Answers = questionDTO.Answers
                .Select(a => new Answer
                {
                    AnswerText = a.Text,
                    IsCorrect = a.IsCorrect,

                }).ToList(),
            };


            await _appDbContext.Question.AddAsync(question);
            await _appDbContext.SaveChangesAsync();

            return new CreateQuestionAnswerResponseModel
            {
                Id = question.Id,
            };

        }
        public async Task<List<QuestionAnswerResponseModel>> GetAllQuestionAnswer()
        {
            var question = await _appDbContext.Question
                .Select(x => new QuestionAnswerResponseModel
                {
                    QuestionText = x.QuestionText,
                    Image = x.ImageUrl,
                    QuestionLevel = x.Level,
                    Answers = x.Answers.
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
                    .Where(x => x.Id == Id)
                    .Select(x => new QuestionAnswerResponseModel
                    {
                        QuestionText = x.QuestionText,
                        Image = x.ImageUrl,
                        QuestionLevel = x.Level,
                        Answers = x.Answers
                                  .Select(n => new AnswerGetAllDTO
                                  {
                                      AnswerText = n.AnswerText,
                                  }).ToList()
                    })
                      .FirstOrDefaultAsync();

            if (question == null)
                throw new NotFoundException("Question topilmadi.");

            return question;

        }
        public async Task<UpdateQuestionAnswerResponseModel> UpdateQuestionAnswer(int id, UpdateQuestionAnswerModel questionUpdateDTO)
        {
            #region
            //string? urlImage = null;
            //if (questionUpdateDTO.Image != null && questionUpdateDTO.Image.Length > 0)
            //{
            //    var extension = Path.GetExtension(questionUpdateDTO.Image.FileName);
            //    var objectName = $"{Guid.NewGuid()}{extension}";

            //    using var mystream = questionUpdateDTO.Image.OpenReadStream();
            //    urlImage = await _fileStorageService.UploadFileAsync(
            //        "questions-image",
            //        objectName,
            //        mystream,
            //        questionUpdateDTO.Image.ContentType
            //    );
            //}
            #endregion

            Question question = await _appDbContext.Question
                    .Include(q => q.Answers)
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (question == null)
                throw new NotFoundException("Question topilmadi.");

            question.QuestionText = questionUpdateDTO.QuestionText;
            //question.ImageUrl = urlImage;
         
            HashSet<int> mySet = new HashSet<int>();
            List<Answer> answersToAssign = new List<Answer>();

            for (int j = 0; j < questionUpdateDTO.Answers.Count(); j++)
            {
                mySet.Add(questionUpdateDTO.Answers[j].Id);
                if (questionUpdateDTO.Answers[j].Id == 0)
                {
                    Answer newAnswer = new Answer
                    {
                        AnswerText = questionUpdateDTO.Answers[j].Text,
                        IsCorrect = questionUpdateDTO.Answers[j].IsCorrect
                    };
                    question.Answers.Add(newAnswer);
                }
                else
                {
                    for (int i = 0; i < question.Answers.Count(); i++)
                    {
                        if (question.Answers[i].Id == questionUpdateDTO.Answers[j].Id)
                        {
                            question.Answers[i].IsCorrect = questionUpdateDTO.Answers[j].IsCorrect;
                            question.Answers[i].AnswerText = questionUpdateDTO.Answers[j].Text;
                        }
                    }
                }
            }

            for(int i = 0; i < question.Answers.Count(); i++)
            {
                if (!mySet.Contains(question.Answers[i].Id))
                {


                    question.Answers.Remove(question.Answers[i]);
                    i--;
                }
            }
            
            _appDbContext.Update(question);
            _appDbContext.SaveChanges();


            //foreach (var answerDto in questionUpdateDTO.Answers)
            //{
            //    var existingAnswer = question.Answers.FirstOrDefault(a => a.Id == answerDto.Id);

            //    if (existingAnswer != null)
            //    {
            //        // mavjud javobni yangilash
            //        existingAnswer.AnswerText = answerDto.Text;
            //        existingAnswer.IsCorrect = answerDto.IsCorrect;
            //    }
            //    else
            //    {
            //        // yangi javob qo‘shish
            //        var newAnswer = new Answer
            //        {
            //            AnswerText = answerDto.Text,
            //            IsCorrect = answerDto.IsCorrect,
            //            QuestionId = question.Id
            //        };

            //        _appDbContext.Answers.Add(newAnswer);
            //    }
            //}


            //_appDbContext.Question.Update(question);
            //await _appDbContext.SaveChangesAsync();

            return new UpdateQuestionAnswerResponseModel { Id = question.Id };
        }
        public async Task<string> DeleteQuestionAnswer(int Id)
        {
            var question = await _appDbContext.Question
                .Include(a => a.Answers)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (question == null)
                throw new NotFoundException("Question topilmadi.");

            // Avval Answer’larni o‘chiramiz
            _appDbContext.Answers.RemoveRange(question.Answers);

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
                    Answers = x.Answers.
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
