namespace TestEducation.Dtos
{
    public class UserQuestionDTO
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswer { get; set; }  
        public DateTime AnsweredAt { get; set; }
        public List<UserQuestionAnswerDTO> UserAnswers { get; set; }
    }
}
