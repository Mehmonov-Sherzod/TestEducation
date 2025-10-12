using TestEducation.Models.Enums;

namespace TestEducation.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string? ImageUrl { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public QuestionLevel Level { get; set; }
        public List<UserQuestion> UserQuestions { get; set; }          
        public List<Answer> AnswerOptions { get; set; }
    }
}
