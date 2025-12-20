using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Data;
using TestEducation.Domain.Entities;
using TestEducation.Domain.Enums;
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
                throw new BadRequestException("Bunday nomli subject allaqachon mavjud");

            var result = new Subject
            {
                Name = subjectDTO.Name,
                SubjectTranslates = subjectDTO.SubjectTranslates
               .Select(x => new SubjectTranslate
                {
                    Language = x.LanguageId,
                    ColumnName = x.ColumnName,
                    TranslateText = x.TranslateText,
                }).ToList()
            };

            try
            {
                await _appDbContext.Subjects.AddAsync(result);
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new BadRequestException("Subject yaratishda xatolik yuz berdi. Subject nomi takrorlanishi mumkin.");
            }

            return new CreateSubjectResponseModel
            {
                Id = result.Id
            };

        }
        public async Task<SubjectResponsModel> GetByIdSubject(Guid id , string lang)
        {
            Language userLanguage = Language.uz;

            if (lang == "uz")
                userLanguage = Language.uz;
            else if (lang == "ru" || lang == "rus")
                userLanguage = Language.rus;
            else if (lang == "eng")
                userLanguage = Language.eng;

            var subject = await _appDbContext.Subjects
                .Where(x => x.Id == id)
                .Select(x => new SubjectResponsModel
                {
                    Id = x.Id,
                    SubjectName = x.Name,
                    Translates = x.SubjectTranslates
                   .Where(t => t.Language == userLanguage)
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
        public async Task<UpdateSubjectResponseModel> UpdateSubject(Guid Id, UpdateSubjectModel subjectDTO)
        {
            var subject = await _appDbContext.Subjects
                .Include(y => y.SubjectTranslates)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");
            
            subject.Name = subjectDTO.SubjectNmae;

            // Remove all existing translations
            subject.SubjectTranslates.Clear();

            // Add new translations
            foreach (var translateModel in subjectDTO.UpdateSubjectTranslateModels)
            {
                subject.SubjectTranslates.Add(new SubjectTranslate
                {
                    Language = translateModel.LanguageId,
                    ColumnName = translateModel.ColumnName,
                    TranslateText = translateModel.TranslateText,
                });
            }

            _appDbContext.Subjects.Update(subject);
            await _appDbContext.SaveChangesAsync();

            return new UpdateSubjectResponseModel
            {
                Id = subject.Id,
            };


        }
        public async Task<string> DeleteSubject(Guid id)
        {
            var subject = await _appDbContext.Subjects
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subject == null)
                throw new NotFoundException("subject topilmadi.");

            _appDbContext.Subjects.Remove(subject);
            await _appDbContext.SaveChangesAsync();

            return "Subject o'chirildi";


        }
        public async Task<PaginationResult<SubjectResponsModel>> CreateSubjectPage(PageOption model,  string lang)
        {
            var query = _appDbContext.Subjects.AsQueryable();

            Language userLanguage = Language.uz;

            if (lang == "uz")
                userLanguage = Language.uz;
            else if (lang == "ru" || lang == "rus")
                userLanguage = Language.rus;
            else if (lang == "eng")
                userLanguage = Language.eng;

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(s => s.Name.Contains(model.Search) ||
                    s.SubjectTranslates.Any(t => t.TranslateText.Contains(model.Search)));
            }
            Console.WriteLine(query.ToQueryString());
            List<SubjectResponsModel> subjects = await query
                .Skip(model.PageSize * (model.PageNumber - 1))
                .Take(model.PageSize)
                .Select(s => new SubjectResponsModel
                {
                    Id = s.Id,
                    // Tanlangan tildagi SubjectName'ni olish
                    SubjectName = s.SubjectTranslates
                        .Where(t => t.Language == userLanguage && t.ColumnName == "SubjectName")
                        .Select(t => t.TranslateText)
                        .FirstOrDefault() ?? s.Name,
                    Translates = s.SubjectTranslates
                   .Where(t => t.Language == userLanguage)
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

        public async Task<List<SubjectResponsModel>> GetAllSubjects(string lang)
        {
            Language userLanguage = Language.uz;

            if (lang == "uz")
                userLanguage = Language.uz;
            else if (lang == "ru" || lang == "rus")
                userLanguage = Language.rus;
            else if (lang == "eng")
                userLanguage = Language.eng;

            var subjects = await _appDbContext.Subjects
                .Select(s => new SubjectResponsModel
                {
                    Id = s.Id,
                    SubjectName = s.SubjectTranslates
                        .Where(t => t.Language == userLanguage && t.ColumnName == "SubjectName")
                        .Select(t => t.TranslateText)
                        .FirstOrDefault() ?? s.Name,
                    Translates = s.SubjectTranslates
                       .Where(t => t.Language == userLanguage)
                       .Select(st => new SubjectTranslateResponseModel
                        {
                            ColumnName = st.ColumnName,
                            TranslateText = st.TranslateText,
                        }).ToList()
                }).ToListAsync();

            return subjects;
        }
    }
}

