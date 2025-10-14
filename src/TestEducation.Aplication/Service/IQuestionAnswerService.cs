using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models.Question;
using TestEducation.Dtos;

namespace TestEducation.Service.QuestionAnswerService
{
    public interface IQuestionAnswerService
    {
        Task<ResponseDTO> CreateQuestionAnswer(QuestionDTO questionDTO);
        Task<ResponseDTO<ICollection<QuestionGetAllDTO>>> GetAllQuestionAnswer();
        Task<ResponseDTO<QuestionGetAllDTO>> GetByIdQuestionAnswer(int Id);
        Task<ResponseDTO> DeleteQuestionAnswer(int Id);
        Task<ResponseDTO<QuestionUpdateDTO>> UpdateQuestionAnswer(int id, QuestionUpdateDTO questionUpdateDTO);
        Task<Stream> DownloadFileAsyncQuestion( string objectName);




    }
}
