using TestEducation.Aplication.Models.TestProcess;
using TestEducation.Aplication.Models.UserQuestionAnswer;

namespace TestEducation.Aplication.Models.UserQuestion
{
    public class UserQuestionModel
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int Order { get; set; }
        public int TextProcessId { get; set; }
        public TestProcessModel TestProcess { get; set; }
        public List<UserQuestionAnswerModel> UserAnswers { get; set; }
    }
}
