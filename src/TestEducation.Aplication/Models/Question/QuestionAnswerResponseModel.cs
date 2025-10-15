using TestEducation.Aplication.Models.Answer;

namespace TestEducation.Aplication.Models.Question
{
    public class QuestionAnswerResponseModel
    {
        public string QuestionText { get; set; }
        public string Image { get; set; }
        public List<AnswerGetAllDTO> Answers { get; set; }
    }
}
