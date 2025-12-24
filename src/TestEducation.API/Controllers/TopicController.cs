using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Aplication.Models.Topic;
using TestEducation.Aplication.Service;
using TestEducation.Domain.Enums;
using TestEducation.Filter;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [RequirePermission(PermissionEnum.ManageTopics)]
        [HttpPost("create - topic")]
        public async Task<IActionResult> CreateTopic([FromBody] CreateTopicModel model)
        {
            var result = await _topicService.CreateTopic(model);
            return Ok(ApiResult<CreateTopicResponseModel>.Success(result));
        }

        [Authorize]
        [HttpGet("paged")]
        public async Task<IActionResult> GetAllPageTopic([FromQuery] TopicPageModel topicPage)
        {
            var result = await _topicService.GetAllPageTopic(topicPage);
            return Ok(ApiResult<PaginationResult<SubjectTopicsResponse>>.Success(result));
        }
        [RequirePermission(PermissionEnum.ManageTopics)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic([FromBody] UpdateTopicModel model, Guid id)
        {
            var result = await _topicService.UpdateTopic(model, id);
            return Ok(ApiResult<UpdateTopicResponseModel>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageTopics)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(Guid id)
        {
            var result = await _topicService.DeleteTopic(id);
            return Ok(ApiResult<string>.Success(result));
        }
    }
}
