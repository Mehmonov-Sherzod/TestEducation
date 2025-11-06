using TestEducation.Aplication.Models.Answer;
using TestEducation.Models;

namespace TestEducation.Aplication.Models.UserQuestionAnswer
{
    public class UserQuestionAnswerModel
    {
        public int Order { get; set; }
        public int UserQuestionId { get; set; }
        public int AnswerId { get; set; }
        public CreateAnswerModel CreateAnswerModel { get; set; }
    }
}
