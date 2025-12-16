using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Aplication.Models.Topic;

namespace TestEducation.Aplication.Service
{
    public interface ITopicService
    {
        Task<CreateTopicResponseModel> CreateTopic(CreateTopicModel model);
        Task<PaginationResult<SubjectTopicsResponse>> GetAllPageTopic(TopicPageModel model);
        Task<UpdateTopicResponseModel> UpdateTopic(UpdateTopicModel model, int Id);
        Task<string> DeleteTopic(int Id);
    }
}
