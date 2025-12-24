using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.BalanceTransaction;
using TestEducation.Aplication.Service;
using TestEducation.Domain.Entities;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoughtSourceController : ControllerBase
    {
        private readonly IBoughtSourceBuyService _boughtSourceBuyService;

        public BoughtSourceController(IBoughtSourceBuyService boughtSourceBuyService)
        {
            _boughtSourceBuyService = boughtSourceBuyService;
        }

        [HttpPost]

        public async Task<IActionResult> BougthBuy(Guid SheredSourceId)
        {
            var result = await  _boughtSourceBuyService.ShareSouceBuy(SheredSourceId);  

            return Ok(ApiResult<string>.Success(result));
        }
    }
}
