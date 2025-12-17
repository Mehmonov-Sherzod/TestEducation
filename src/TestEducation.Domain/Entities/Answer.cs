using TestEducation.Domain.Entities;

namespace TestEducation.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public List<AnswerTranslate> answerTranslates { get; set; }

    }
}
