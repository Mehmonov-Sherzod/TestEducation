using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.UserBalance;
using TestEducation.Aplication.Service;
using TestEducation.Domain.Enums;
using TestEducation.Filter;

namespace TestEducation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserBalanceController : ControllerBase
    {
        private readonly IUserBalandeService _userBalandeService;

        public UserBalanceController(IUserBalandeService userBalandeService)
        {
            _userBalandeService = userBalandeService;   
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMyBalance()
        {
            var result = await _userBalandeService.GetMyBalance();  

            return Ok(ApiResult<GetMeUserBalance>.Success(result));

        }

        [RequirePermission(PermissionEnum.ManageAdmins)]
        [HttpPost]

        public async Task<IActionResult> GetAllPageUserBalance(PageOption pageOption)
        {
            var result = await _userBalandeService.GetAllPageUserBalance(pageOption);

            return Ok(ApiResult<PaginationResult<GetAllPageUserBalance>>.Success(result));

        }

        [RequirePermission(PermissionEnum.ManageAdmins)]
        [HttpPut]

        public async Task<IActionResult> UpdateUserBalance(UpdateUserBalance updateUserBalance , Guid Id, decimal Amount)
        {
            var result = await _userBalandeService.UpdateUserBalance(updateUserBalance, Id, Amount);

            return Ok(ApiResult<string>.Success(result));

        }
    }
}
