using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Telegram.Bot.Types;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models.StartTestMixed;
using TestEducation.Aplication.Models.TestProcsess;
using TestEducation.Aplication.Models.UserQuestion;
using TestEducation.Aplication.Models.UserQuestionAnswer;
using TestEducation.Data;
using TestEducation.Domain.Entities;
using TestEducation.Domain.Enums;
using TestEducation.Models;

namespace TestEducation.Aplication.Service.Impl
{
    public class StartTestService : IStartTestService
    {
        private readonly AppDbContext _appDbContext;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public StartTestService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TestProcessResponce> StartTestMixed30(StartTestMixedModels StartTestMixedModels)
        {
            var id = Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Subject = await _appDbContext.Subjects.Where(x => x.Id == StartTestMixedModels.SubjectId).FirstOrDefaultAsync();

            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            var query = _appDbContext.Question.Include(x => x.Answers).Where(x => x.SubjectId == StartTestMixedModels.SubjectId);

            if (!string.IsNullOrEmpty(StartTestMixedModels.TopicId.ToString()))
            {
                query = query.Where(x => x.TopicId == StartTestMixedModels.TopicId);
            }
            var query1 = await query.ToListAsync();

            var QuestionEasy = query1.Where(x => x.Level == QuestionLevel.Easy)
                     .OrderBy(x => Guid.NewGuid()).Take(15);

            if (QuestionEasy.Count() < 15)
                throw new BadRequestException("Test Boshlashga easy savol yetarli emas");

            var QuestionMedium = query1.Where(x => x.Level == QuestionLevel.Medium)
                     .OrderBy(x => Guid.NewGuid()).Take(8);

            if (QuestionMedium.Count() < 7)
                throw new BadRequestException("Test Boshlashga medium savol yetarli emas");

            var QuestionHard = query1.Where(x => x.Level == QuestionLevel.Hard)
                     .OrderBy(x => Guid.NewGuid()).Take(7);

            if (QuestionHard.Count() < 7)
                throw new BadRequestException("Test Boshlashga hard savol yetarli emas");


            var questionsMixed = QuestionEasy.Concat(QuestionMedium).Concat(QuestionHard).ToList();



            TestProcess testProcess = new TestProcess()
            {
                Id = Guid.NewGuid(),
                UserId = id,
                StartedAt = DateTime.UtcNow.AddHours(5),
                EndsAt = DateTime.UtcNow.AddHours(6),
                TotalQuestions = 30,
                IncorrectAnswers = 0,
                CorrectAnswers = 0,
                TotalScore = 0,
                PercentageOfCorrectAnswers = 0,
                UserQuestions = new List<UserQuestion>()
            };
            foreach (var item in questionsMixed)
            {
                var userquestion = new UserQuestion
                {
                    Id = Guid.NewGuid(),    
                    QuestionId = item.Id,
                    QuestionText = item.QuestionText,
                    TestProcessId = testProcess.Id,
                    SubjectName = Subject.Name,
                    UserId = id,
                    UserQuestionAnswers = new List<UserQuestionAnswer>()
                };
                foreach(var item1 in item.Answers)
                {
                    var userquestionanswer = new UserQuestionAnswer
                    {
                        Id = Guid.NewGuid(),        
                        UserQuestionId = userquestion.Id,
                        AnswerText = item1.AnswerText,
                        IsMarked = false,
                        IsCorrect = item1.IsCorrect,

                    };
                    userquestion.UserQuestionAnswers.Add(userquestionanswer);
                }
                testProcess.UserQuestions.Add(userquestion);
            }

            _appDbContext.TestProcesses.Add(testProcess);           
            await _appDbContext.SaveChangesAsync();


            var testProcsessModel = await _appDbContext.TestProcesses
                .Where(x=>x.Id == testProcess.Id)
                .Include(x => x.UserQuestions)
                .ThenInclude(x => x.UserQuestionAnswers)
                .FirstOrDefaultAsync();


            var procsess = new TestProcessResponce
            {
                Id = testProcsessModel.Id,
                StartedAt = DateTime.UtcNow,
                UserId = id,
                EndsAt = DateTime.UtcNow.AddHours(1),
            };
            var userQuest = new List<UserQuestionResponce>();
            foreach (var QuestionItem in testProcsessModel.UserQuestions)
            {
                var userquestionResponce = new UserQuestionResponce
                {   
                    TextProcessId = testProcsessModel.Id,
                    QuestionText = QuestionItem.QuestionText,
                };
                var userQuestAnswers = new List<UserQuestionAnswerResponce>();
                foreach (var AnswerItem in QuestionItem.UserQuestionAnswers)
                {
                    var userquestionanswer = new UserQuestionAnswerResponce
                    {
                        UserQuestionId = QuestionItem.Id,
                        IsMarked = false,
                        AnswerText = AnswerItem.AnswerText
                    };
                    userQuestAnswers.Add(userquestionanswer);
                }
                userquestionResponce.UserQuestionAnswers = userQuestAnswers;
                userQuest.Add(userquestionResponce);
            }

            return procsess;

        }
    }
}
