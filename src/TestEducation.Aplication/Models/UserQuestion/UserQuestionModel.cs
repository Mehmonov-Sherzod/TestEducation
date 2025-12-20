using TestEducation.Aplication.Models.TestProcess;
using TestEducation.Aplication.Models.UserQuestionAnswer;

namespace TestEducation.Aplication.Models.UserQuestion
{
    public class UserQuestionModel
    {
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public int Order { get; set; }
        public Guid TextProcessId { get; set; }
        public TestProcessModel TestProcess { get; set; }
        public List<UserQuestionAnswerModel> UserAnswers { get; set; }
    }
}
