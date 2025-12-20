using TestEducation.Aplication.Models.Answer;
using TestEducation.Domain.Enums;

namespace TestEducation.Aplication.Models.Question
{
    public class QuestionAnswerResponseModel
    {
        public Guid Id { get; set; } 
        public string QuestionText { get; set; }
        public string Image { get; set; }
        public QuestionLevel QuestionLevel { get; set; }    
        public List<QuestionTranslateResponseModel> Translate { get; set; }
        public List<AnswerResponseModel> Answers { get; set; }
    }
}
