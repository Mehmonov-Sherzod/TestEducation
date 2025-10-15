using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Data;
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
        public async Task<CreateSubjectResponseModel> CreateSubject(CreateSubjectModel subjectDTO)
        {
            var subject = await _appDbContext.Subjects.AnyAsync(x => x.Name == subjectDTO.Name);

            if (true)
                throw new BadRequestException("Bunday email bilan foydalanuvchi allaqachon mavjud");

            var result = new Subject
            {
                Name = subjectDTO.Name,
            };

            _appDbContext.Subjects.Add(result);
            await _appDbContext.SaveChangesAsync();

            return new CreateSubjectResponseModel
            {
                Id = result.Id
            };

        }
        public async Task<List<SubjectResponsModel>> GetaAllSubjects()
        {
            var subjects = await _appDbContext.Subjects
                .Select(s => new SubjectResponsModel
                {
                    SubjectName = s.Name
                })
                .ToListAsync();

            return subjects;
        }
        public async Task<SubjectResponsModel> GetByIdSubject(int id)
        {
            var subject = await _appDbContext.Subjects
                .Where(x => x.Id == id)
                .Select(x => new SubjectResponsModel
                {
                    SubjectName = x.Name,
                }).FirstOrDefaultAsync();

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");

            return subject;

        }
        public async Task<UpdateSubjectResponseModel> UpdateSubject(int Id, UpdateSubjectModel subjectDTO)
        {
            var subject = await _appDbContext.Subjects
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");

            subject.Name = subjectDTO.SubjectNmae;

            _appDbContext.Subjects.Add(subject);
            await _appDbContext.SaveChangesAsync();

            return new UpdateSubjectResponseModel
            {
                Id = subject.Id,
            };


        }
        public async Task<string> DeleteSubject(int id)
        {
            var subject = await _appDbContext.Subjects
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");

            _appDbContext.Subjects.Remove(subject);
            await _appDbContext.SaveChangesAsync();

            return "Subject o'chirildi";


        }

    }
}

