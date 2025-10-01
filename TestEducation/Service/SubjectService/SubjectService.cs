using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;

namespace TestEducation.Service.SubjectService
{
    public class SubjectService : ISubjectServise
    {
        private readonly AppDbContext _appDbContext;

        public SubjectService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDTO> CreateSubject(SubjectDTO subjectDTO)
        {
            var subject = await _appDbContext.subjects.AnyAsync(x => x.Name ==  subjectDTO.Name);

            if (subject)
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "bunday nomdagi fan bor",
                    StatusCode = 404,
                };

            var result = new SubjectDTO
            {
                Name = subjectDTO.Name,
            };

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "fan qoshildi",
                StatusCode = 200,
            };

        }

        public async Task<ResponseDTO<SubjectDTO>> GetByIdSubject(int id)
        {
            var subject = await _appDbContext.subjects
                .Where(x => x.Id == id)
                .Select(x => new SubjectDTO
                {
                    Name = x.Name,
                }).FirstOrDefaultAsync();

                if (subject == null)
                   return new ResponseDTO<SubjectDTO>
                   {
                    IsSuccess = false,
                    Message = " bunday id li fan topilmadi",
                    StatusCode = 404,
                   };

               return new ResponseDTO<SubjectDTO>
                {
                   IsSuccess = true,
                   Message = "fan topildi",
                   StatusCode = 200,
                   Data = subject,
                };

        }
        public async Task<ResponseDTO<ICollection<SubjectDTO>>> GetaAllSubjects()
        {
            var subject = await _appDbContext.subjects
                .Select(x => new SubjectDTO
                {
                    Name = x.Name,
                }).ToListAsync();

            return new ResponseDTO<ICollection<SubjectDTO>>
            {
                Message = "fan qo'shildi",
                StatusCode = 200,
                Data = subject,
            };
        }

        public async Task<ResponseDTO<SubjectDTO>> UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            var subject = await _appDbContext.subjects
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subject == null)
                return new ResponseDTO<SubjectDTO>
                {
                    IsSuccess = false,
                    Message = "Bunday Id Mavjud emas",
                    StatusCode = 404,
                    Data = null,
                };

            subject.Name = subjectDTO.Name;

            _appDbContext.subjects.Add(subject);
            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO<SubjectDTO>
            {
                IsSuccess = true,
                Message = "Update bo;ldi",
                StatusCode = 200,
                Data = subjectDTO,
            };

        }
        public async Task<ResponseDTO> DeleteSubject(int id)
        {
            var subject = await  _appDbContext.subjects
                .FirstOrDefaultAsync (x => x.Id == id);

            if (subject == null)
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Bunday id mavjud emas",
                    StatusCode = 404,

                };

              _appDbContext.subjects.Remove(subject);
              await _appDbContext.SaveChangesAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Malumot o'chirildi"
            };

        }

    }
}
