using TestEducation.Dtos;

namespace TestEducation.Service.QuestionLevelService
{
    public class QuestionLevelService : IQuestionLevelService
    {
        public Task<ResponseDTO> CreateQuestionLevel()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<QuestionLevelDTO>> DeleteByIdQuestionLevel(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ICollection<QuestionLevelDTO>>> GetAllQuestionLevel()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<QuestionLevelDTO>> GetByIdQuestionLevel()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<QuestionLevelDTO>> UpdateQuestionLevel(int Id, QuestionLevelDTO questionLevel)
        {
            throw new NotImplementedException();
        }
    }
}
