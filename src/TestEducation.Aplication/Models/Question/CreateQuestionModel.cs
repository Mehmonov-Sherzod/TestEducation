
using TestEducation.Aplication.Models.Answer;
using TestEducation.Domain.Enums;

namespace TestEducation.Aplication.Models.Question
{
    public class CreateQuestionModel
    {
        public string QuestionText { get; set; }
        public int SubjectId { get; set; }
        public IFormFile? Image { get; set; }
        public QuestionLevel Level { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }

    public class CreateQuestionAnswerResponseModel : BaseResponseModel;
}
