using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Aplication.Models.Topic;
using TestEducation.Data;
using TestEducation.Domain.Entities;

namespace TestEducation.Aplication.Service.Impl
{
    public class TopicService : ITopicService
    {
        private readonly AppDbContext _appDbContext;

        public TopicService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CreateTopicResponseModel> CreateTopic(CreateTopicModel model)
        {
            var exists = await _appDbContext.topics.AnyAsync(x => x.Name == model.TopicName && x.SubjectId == model.SubjectId);

            if (exists)
                throw new BadRequestException("Bu mavzu allaqachon mavjud");

            var subject = await _appDbContext.Subjects.FindAsync(model.SubjectId);
            if (subject == null)
                throw new NotFoundException("Fan topilmadi");

            var topic = new Topic
            {
                Name = model.TopicName,
                SubjectId = model.SubjectId,
            };

            await _appDbContext.topics.AddAsync(topic);
            await _appDbContext.SaveChangesAsync();

            return new CreateTopicResponseModel
            {
                Id = topic.Id
            };
        }

        public async Task<string> DeleteTopic(Guid Id)
        {
            var topic = await _appDbContext.topics.FirstOrDefaultAsync(x => x.Id == Id);

            if (topic == null)
                throw new NotFoundException("Mavzu topilmadi");

            _appDbContext.topics.Remove(topic);
            await _appDbContext.SaveChangesAsync();

            return "Mavzu o'chirildi";
        }

        public async Task<PaginationResult<SubjectTopicsResponse>> GetAllPageTopic(TopicPageModel model)
        {
            var query = _appDbContext.topics
                        .Include(t => t.Subject)
                        .Include(t => t.Questions)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(s => s.Name.Contains(model.Search));
            }

            if (model.SubjectId != null) // yoki Nullable bo'lsa: model.SubjectId.HasValue
            {
                query = query.Where(t => t.SubjectId == model.SubjectId);
            }

            int total = await query.CountAsync();

            var groupedTopics = await query
                .GroupBy(t => new { t.SubjectId, t.Subject.Name })
                .Select(g => new SubjectTopicsResponse
                {
                    SubjectId = g.Key.SubjectId,
                    SubjectName = g.Key.Name,
                    Topics = g.Select(x => new TopicResponseModel
                    {
                        Id = x.Id,
                        TopicName = x.Name,
                        SubjectId = x.SubjectId,
                        SubjectName = g.Key.Name,
                        QuestionCount = x.Questions.Count
                    }).ToList()
                })
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToListAsync();

            return new PaginationResult<SubjectTopicsResponse>
            {
                Values = groupedTopics,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                TotalCount = total
            };

        }

        public async Task<UpdateTopicResponseModel> UpdateTopic(UpdateTopicModel model, Guid Id)
        {
            var topic = await _appDbContext.topics.FirstOrDefaultAsync(x => x.Id == Id);

            if (topic == null)
                throw new NotFoundException("Mavzu topilmadi");

            topic.Name = model.TopicName;

            _appDbContext.Update(topic);
            await _appDbContext.SaveChangesAsync();

            return new UpdateTopicResponseModel
            {
                Id = topic.Id,
            };
        }
    }
}
