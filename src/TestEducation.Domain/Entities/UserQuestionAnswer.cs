namespace TestEducation.Models
{
    public class UserQuestionAnswer
    {
        public int Id { get; set; }
        public int UserQuestionId { get; set; }
        public UserQuestion UserQuestion { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsMarked { get; set; } = false;
        public string AnswerText { get; set; }

    }
}
