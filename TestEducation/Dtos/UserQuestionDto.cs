namespace TestEducation.Dtos
{
    public class UserQuestionDto
    {

        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswer { get; set; }  
        public DateTime AnsweredAt { get; set; }
        public string QuestionText { get; set; }

       // public List<UserQuestionAnswerDto> UserAnswers { get; set; }
    }
}
