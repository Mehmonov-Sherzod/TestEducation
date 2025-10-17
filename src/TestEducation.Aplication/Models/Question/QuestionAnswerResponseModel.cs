using TestEducation.Aplication.Models.Answer;
using TestEducation.Domain.Enums;

namespace TestEducation.Aplication.Models.Question
{
    public class QuestionAnswerResponseModel
    {
        public string QuestionText { get; set; }
        public string Image { get; set; }
        public QuestionLevel QuestionLevel { get; set; }    
        public List<AnswerGetAllDTO> Answers { get; set; }
    }
}
