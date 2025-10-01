using System.Drawing;
using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Migrations;
using TestEducation.Models;

namespace TestEducation.Service.QuestionLevelService
{
    public class QuestionLevelService : IQuestionLevelService
    {
        private readonly AppDbContext _appDbContext;

        public QuestionLevelService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDTO> CreateQuestionLevel(QuestionLevelDTO questionLevelDTO)
        {
            var rezult = await _appDbContext.questionLevel.AnyAsync(x => x.Level == questionLevelDTO.Level);

            if (rezult)
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "bunay Level Mavjud",
                };

            var levelquest = new QuestionLevel
            {
                Level = questionLevelDTO.Level,
                Point = questionLevelDTO.Point
            };

            _appDbContext.questionLevel.Add(levelquest);
            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO<QuestionDTO>
            {
                IsSuccess = true,
                Message = "Level Qo'shildi"
            };
        }

        public Task<ResponseDTO<QuestionLevelDTO>> DeleteByIdQuestionLevel(int Id)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResponseDTO<QuestionLevelDTO>> DeleteByIdQuestionLevel(int Id)
        //{
        //   var rezult = await  _appDbContext.questionLevel.FirstOrDefaultAsync(x => x.Id == Id);





        //}

        public Task<ResponseDTO<ICollection<QuestionLevelDTO>>> GetAllQuestionLevel()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<QuestionLevelDTO>> GetByIdQuestionLevel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<QuestionLevelDTO>> UpdateQuestionLevel(int Id, QuestionLevelDTO questionLevel)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDTO<QuestionDTO>> IQuestionLevelService.GetByIdQuestionLevel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
