using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.BalanceTransaction;
using TestEducation.Aplication.Service;
using TestEducation.Domain.Enums;
using TestEducation.Filter;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceTransactionController : ControllerBase
    {
        private readonly IBalanceTransactionService _balanceTransactionService;

        public BalanceTransactionController(IBalanceTransactionService balanceTransactionService)
        {
            _balanceTransactionService = balanceTransactionService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBalanceTransaction()
        {
            var result = await _balanceTransactionService.GetBalanceTransaction();

            return Ok(ApiResult<BalanceTransactionResponce>.Success(result));
        }

        [RequirePermission(PermissionEnum.ManageAdmins)]
        [HttpPut]
        public async Task<IActionResult> UpdateBalanceTransaction(BalanceTransactionUpdate balanceTransactionUpdate, Guid Id)
        {
            var result = await _balanceTransactionService.UpdateBalanceTransaction(balanceTransactionUpdate , Id);

            return Ok(ApiResult<string>.Success(result));
        }
    }
}
