using TestEducation.Dtos;

namespace TestEducation.Service.QuestionLevelService
{
    public interface IQuestionLevelService
    {
        Task<string> CreateQuestionLevel();
        Task<ICollection<QuestionLevelDTO>> GetAllQuestionLevel();
        Task<QuestionLevelDTO> GetByIdQuestionLevel();
        Task<QuestionLevelDTO> UpdateQuestionLevel(int Id , QuestionLevelDTO questionLevel);
        Task<QuestionLevelDTO> DeleteByIdQuestionLevel(int Id);
    }
}
