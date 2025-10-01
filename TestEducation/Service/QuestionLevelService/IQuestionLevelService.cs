using TestEducation.Dtos;

namespace TestEducation.Service.QuestionLevelService;

public interface IQuestionLevelService
{
    Task<ResponseDTO> CreateQuestionLevel(QuestionLevelDTO questionLevelDTO);
    Task<ResponseDTO<ICollection<QuestionLevelDTO>>> GetAllQuestionLevel();
    Task<ResponseDTO<QuestionLevelDTO>> GetByIdQuestionLevel(int id);
    Task<ResponseDTO<QuestionLevelDTO>> UpdateQuestionLevel(int Id , QuestionLevelDTO questionLevel);
    Task<ResponseDTO<QuestionLevelDTO>> DeleteByIdQuestionLevel(int Id);
}
