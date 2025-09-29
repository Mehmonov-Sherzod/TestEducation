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

        public async Task<string> CreateSubject(SubjectDto subjectDto)
        {
            
            var subject = await _appDbContext.subjects.AnyAsync( x => x.Name == subjectDto.Name );

            if (subject)
                return "bu nomli subject bor";

            var Subject = new Subject
            {
                Name = subjectDto.Name,

            };

            _appDbContext.subjects.Add(Subject);
            _appDbContext.SaveChanges();

            return "Subject Qo'shildi";

        }

        public Task<string> DeleteSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectDto>> GetaAllSubjects()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectDto> GetByIdSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateSubject(int id, SubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }
    }
}
