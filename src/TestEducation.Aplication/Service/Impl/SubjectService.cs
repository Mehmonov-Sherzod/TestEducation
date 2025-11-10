using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Data;
using TestEducation.Domain.Entities;
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

            if (subject)
                throw new BadRequestException("bunday kitob mavjud");

            var result = new Subject
            {
                Name = subjectDTO.Name,
                SubjectTranslates = subjectDTO.SubjectTranslates
                .Select(x => new SubjectTranslate
                {
                    LanguageId = x.LanguageId,
                    ColumnName = x.ColumnName,
                    TranslateText = x.TranslateText,
                }).ToList()
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
                    SubjectName = s.Name,
                    SubjectTranslateResponseModels = s.SubjectTranslates
                   .Select(x => new SubjectTranslateResponseModel
                   {
                       ColumnName = x.ColumnName,
                       TranslateText = x.TranslateText,
                   }).ToList()

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
                    SubjectTranslateResponseModels = x.SubjectTranslates
                   .Select(s => new SubjectTranslateResponseModel
                   {
                       ColumnName = s.ColumnName,
                       TranslateText = s.TranslateText,
                   }).ToList()
                }).FirstOrDefaultAsync();

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");

            return subject;

        }
        public async Task<UpdateSubjectResponseModel> UpdateSubject(int Id, UpdateSubjectModel subjectDTO)
        {
            var subject = await _appDbContext.Subjects
                .Include(y => y.SubjectTranslates)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");

            subject.Name = subjectDTO.SubjectNmae;

            HashSet<int> mySet = new HashSet<int>();


            for (int j = 0; j < subjectDTO.UpdateSubjectTranslateModels.Count(); j++)
            {
                mySet.Add(subjectDTO.UpdateSubjectTranslateModels[j].Id);

                if (subjectDTO.UpdateSubjectTranslateModels[j].Id == 0)
                {
                    SubjectTranslate NewsubjectTranslate = new SubjectTranslate
                    {
                        ColumnName = subjectDTO.UpdateSubjectTranslateModels[j].ColumnName,
                        TranslateText = subjectDTO.UpdateSubjectTranslateModels[j].TranslateText,
                    };

                    subject.SubjectTranslates.Add(NewsubjectTranslate);
                }
                else
                {
                    for(int i = 0; i < subject.SubjectTranslates.Count(); i++)
                    {
                        if (subject.SubjectTranslates[i].id == subjectDTO.UpdateSubjectTranslateModels[j].Id)
                        {
                            subject.SubjectTranslates[i].ColumnName = subjectDTO.UpdateSubjectTranslateModels[j].ColumnName;
                            subject.SubjectTranslates[i].TranslateText = subjectDTO.UpdateSubjectTranslateModels[j].TranslateText;
                        }
                    }
                }
            }

            for(int i = 0; i < subject.SubjectTranslates.Count(); i++)
            {
                if (!mySet.Contains(subject.SubjectTranslates[i].id))
                {
                    subject.SubjectTranslates.Remove(subject.SubjectTranslates[i]);
                    i--;
                }
            }

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
        public async Task<PaginationResult<SubjectResponsModel>> CreateSubjectPage(PageOption model)
        {
            var query = _appDbContext.Subjects.AsQueryable();

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(s => s.Name.Contains(model.Search));
            }
            Console.WriteLine(query.ToQueryString());
            List<SubjectResponsModel> subjects = await query
                .Skip(model.PageSize * (model.PageNumber - 1))
                .Take(model.PageSize)
                .Select(s => new SubjectResponsModel
                {
                    SubjectName = s.Name,
                    SubjectTranslateResponseModels = s.SubjectTranslates
                   .Select(s => new SubjectTranslateResponseModel
                    {
                        ColumnName = s.ColumnName,
                        TranslateText = s.TranslateText,
                    }).ToList()
                }).ToListAsync();

            int total = _appDbContext.Subjects.Count();

            return new PaginationResult<SubjectResponsModel>
            {
                Values = subjects,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                TotalCount = total
            };
        }
    }
}

