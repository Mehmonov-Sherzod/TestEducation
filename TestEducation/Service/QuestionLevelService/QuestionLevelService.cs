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
                    StatusCode = 400,
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
                Message = "Level Qo'shildi",
                StatusCode = 201,
                          
            };
        }

        public async Task<ResponseDTO<ICollection<QuestionLevelDTO>>> GetAllQuestionLevel()
        {
            var level = await _appDbContext.questionLevel
                .Select(x => new QuestionLevelDTO
                {
                    Level = x.Level,
                    Point = x.Point,
                }).ToListAsync();

            return new ResponseDTO<ICollection<QuestionLevelDTO>>
            {
                IsSuccess = true,
                Message = "malumotlar olindi",
                StatusCode = 200,
                Data = level,
            };
        }
        public async Task<ResponseDTO<QuestionLevelDTO>> GetByIdQuestionLevel(int id)
        {
            var result = await _appDbContext.questionLevel.
                Where(x => x.Id == id).
                Select(x => new QuestionLevelDTO
                {
                    Level = x.Level,
                    Point = x.Point,
                }).FirstOrDefaultAsync();

            if (result == null)
                return new ResponseDTO<QuestionLevelDTO>
                {
                    IsSuccess = false,
                    Message = "bunday id ga ega questionlevel mavjud emas",
                    StatusCode = 404,
                    Data = null
                };

            return new ResponseDTO<QuestionLevelDTO>
            {
                IsSuccess = true,
                Message = "obyekt topildi",
                StatusCode = 201,
                Data = result
            };
        }

        public Task<ResponseDTO<QuestionLevelDTO>> UpdateQuestionLevel(int Id, QuestionLevelDTO questionLevel)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDTO<QuestionDTO>> IQuestionLevelService.GetByIdQuestionLevel(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDTO<QuestionLevelDTO>> DeleteByIdQuestionLevel(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
