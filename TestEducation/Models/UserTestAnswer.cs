namespace TestEducation.Models
{
    public class UserTestAnswer
    {
        public int Id { get; set; }

        public int UserTestId { get; set; }
        public UserTest UserTest { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int? AnswerOptionId { get; set; }
        public AnswerOption AnswerOption { get; set; }

        public bool IsCorrect { get; set; }
    }
}
                                                                                                