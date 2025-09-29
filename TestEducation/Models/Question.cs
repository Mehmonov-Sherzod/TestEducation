namespace TestEducation.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int QuestionLevelId { get; set; }
        public QuestionLevel Level { get; set; }
        public List<UserQuestion> UserQuestions { get; set; }          
        public List<AnswerOption> AnswerOptions { get; set; }
    }
}
