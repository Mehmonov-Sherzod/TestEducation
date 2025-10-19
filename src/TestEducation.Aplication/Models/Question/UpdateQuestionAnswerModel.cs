using Microsoft.AspNetCore.Http;
using TestEducation.Aplication.Models.Answer;
using TestEducation.Domain.Enums;

namespace TestEducation.Aplication.Models.Question
{
    public class UpdateQuestionAnswerModel
    {
        public string QuestionText { get; set; }
        //public IFormFile? Image { get; set; }
        public QuestionLevel Level { get; set; }
        public List<UpdateAnswerModel> Answers { get; set; }
    }

    public class UpdateQuestionAnswerResponseModel : BaseResponseModel;
}
