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

        public Task<ResponseDTO> CreateSubject(SubjectDTO subjectDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> DeleteSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ICollection<SubjectDTO>>> GetaAllSubjects()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<SubjectDTO>> GetByIdSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<SubjectDTO>> UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            throw new NotImplementedException();
        }
    }
}
