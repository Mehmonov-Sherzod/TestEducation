
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Question;


namespace TestEducation.Service.QuestionAnswerService
{
    public interface IQuestionAnswerService
    {
        Task<CreateQuestionAnswerResponseModel> CreateQuestionAnswer(CreateQuestionModel questionDTO);
        Task<QuestionAnswerResponseModel> GetByIdQuestionAnswer(Guid Id, string lang);
        Task<UpdateQuestionAnswerResponseModel> UpdateQuestionAnswer(Guid id, UpdateQuestionAnswerModel questionUpdateDTO);
        Task<string> DeleteQuestionAnswer(Guid Id);
        Task<Stream> DownloadFileAsyncQuestion(string objectName);
        Task<PaginationResult<QuestionAnswerResponseModel>> CreateQuestionAnswerPage(PageOption model, string lang, Guid? TopicId, Guid SubjectId);

    }
}
