using TestEducation.Models;

namespace TestEducation.Aplication.Models.UserQuestionAnswer
{
    public class UserQuestionAnswerDTO
    {
        public int Order { get; set; }
        public int UserQuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
