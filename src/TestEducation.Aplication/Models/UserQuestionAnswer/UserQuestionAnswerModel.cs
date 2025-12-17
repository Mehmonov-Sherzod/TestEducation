using TestEducation.Aplication.Models.Answer;
using TestEducation.Models;

namespace TestEducation.Aplication.Models.UserQuestionAnswer
{
    public class UserQuestionAnswerModel
    {
        public bool IsCorrect { get; set; }
        public bool IsMarked { get; set; } = false;
        public string AnswerText { get; set; }
    }
}
