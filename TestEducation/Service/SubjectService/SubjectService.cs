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

        public async Task<string> CreateSubject(SubjectDTO subjectDTO)
        {
            
            var subject = await _appDbContext.subjects.AnyAsync( x => x.Name == subjectDTO.Name );

            if (subject)
                return "bu nomli subject bor";

            var Subject = new Subject
            {
                Name = subjectDTO.Name,

            };

           _appDbContext.subjects.Add(Subject);
           await  _appDbContext.SaveChangesAsync();

            return "Subject Qo'shildi";
        }

        public Task<string> DeleteSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectDTO>> GetaAllSubjects()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectDTO> GetByIdSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            throw new NotImplementedException();
        }
    }
}
