using TestEducation.Aplication.Models.UserQuestionAnswer;

namespace TestEducation.Aplication.Models.UserQuestion
{
    public class UserQuestionDTO
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int Order { get; set; }  
        public bool IsAnswer { get; set; }  
        public DateTime AnsweredAt { get; set; }
        public List<UserQuestionAnswerDTO> UserAnswers { get; set; }
    }
}
