using TestEducation.Domain.Entities;
using TestEducation.Domain.Enums;

namespace TestEducation.Models
{
    public class Question
    {
        public Guid Id { get; set; } 
        public string QuestionText { get; set; }
        public string? ImageUrl { get; set; }
        public QuestionLevel Level { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
        public List<UserQuestion> UserQuestions { get; set; }          
        public List<Answer> Answers { get; set; }
        public List<QuestionTranslation> QuestionTranslations { get; set; }
    }
}
