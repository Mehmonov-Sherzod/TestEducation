
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Question;


namespace TestEducation.Service.QuestionAnswerService
{
    public interface IQuestionAnswerService
    {
        Task<CreateQuestionAnswerResponseModel> CreateQuestionAnswer(CreateQuestionModel questionDTO);
        Task<QuestionAnswerResponseModel> GetByIdQuestionAnswer(int Id, string lang);
        Task<UpdateQuestionAnswerResponseModel> UpdateQuestionAnswer(int id, UpdateQuestionAnswerModel questionUpdateDTO);
        Task<string> DeleteQuestionAnswer(int Id);
        Task<Stream> DownloadFileAsyncQuestion(string objectName);
        Task<PaginationResult<QuestionAnswerResponseModel>> CreateQuestionAnswerPage(PageOption model, string lang);

    }
}
