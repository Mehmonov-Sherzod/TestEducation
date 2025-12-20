namespace TestEducation.Models
{
    public class UserQuestionAnswer
    {
        public Guid Id { get; set; } 
        public Guid UserQuestionId { get; set; }
        public UserQuestion UserQuestion { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsMarked { get; set; } = false;
        public string AnswerText { get; set; }

    }
}
