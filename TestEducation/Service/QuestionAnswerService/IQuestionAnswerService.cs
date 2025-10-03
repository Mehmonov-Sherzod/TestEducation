using Microsoft.AspNetCore.Mvc;
using TestEducation.Dtos;

namespace TestEducation.Service.QuestionAnswerService
{
    public interface IQuestionAnswerService
    {
        Task<ResponseDTO> CreateQuestionAnswer(QuestionDTO questionDTO);
        Task<ResponseDTO<ICollection<QuestionGetAllDTO>>> GetAllQuestionAnswer();
        Task<ResponseDTO<QuestionGetAllDTO>> GetByIdQuestionAnswer(int Id);
        Task<ResponseDTO> DeleteQuestionAnswer(int Id);
        Task<IActionResult> UpdateQuestionAnswer(int id, QuestionUpdateDTO questionUpdateDTO);
    }
}
