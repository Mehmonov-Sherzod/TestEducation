namespace TestEducation.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int QuestionLevelId { get; set; }
        public QuestionLevel Level { get; set; }
        public List<AnswerOption> AnswerOptions { get; set; }
    }
}
