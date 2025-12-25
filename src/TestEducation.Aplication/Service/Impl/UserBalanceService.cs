using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.UserBalance;
using TestEducation.Data;

namespace TestEducation.Aplication.Service.Impl
{
    public class UserBalanceService : IUserBalandeService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _Httpcontext;

        public UserBalanceService(AppDbContext appDbContext, IHttpContextAccessor httpcontext)
        {
            _appDbContext = appDbContext;
            _Httpcontext = httpcontext;
        }

        public async Task<PaginationResult<GetAllPageUserBalance>> GetAllPageUserBalance(PageOption pageOption)
        {
            var query = _appDbContext.UserBalances.AsQueryable();

            if (!string.IsNullOrEmpty(pageOption.Search))
            {
                query = query.Where(s => s.BalanceCode.Contains(pageOption.Search));
            }
            Console.WriteLine(query.ToQueryString());
            List<GetAllPageUserBalance> UserBalance = await query
                .Skip(pageOption.PageSize * (pageOption.PageNumber - 1))
                .Take(pageOption.PageSize)
                .Select(x => new GetAllPageUserBalance
                {
                    Id = x.Id,
                    BalanceCode = x.BalanceCode,
                    Amout = x.Amout,
                    FullName = x.User.FullName
                }).ToListAsync();

            int total = _appDbContext.UserBalances.Count();

            return new PaginationResult<GetAllPageUserBalance>
            {
                Values = UserBalance,
                PageSize = pageOption.PageSize,
                PageNumber = pageOption.PageNumber,
                TotalCount = total
            };
        }

        public async Task<GetMeUserBalance> GetMyBalance()
        {
            var id = Guid.Parse(_Httpcontext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var BalanceUser = await _appDbContext.UserBalances
                .Where(x => x.UserId == id)
                .Select(x => new GetMeUserBalance
                {
                   BalanceCode = x.BalanceCode,
                   Amout = x.Amout,
                })
                .FirstAsync();

            return BalanceUser; 
        }

        public async Task<string> UpdateUserBalance(UpdateUserBalance updateUserBalance, Guid Id, decimal Amount)
        {
            var Balance = await _appDbContext.UserBalances.FirstOrDefaultAsync(x => x.Id == Id);

           
            Balance.Amout = updateUserBalance.Amout;
            Balance.Amout += Amount;

            _appDbContext.UserBalances.Update(Balance);
            await _appDbContext.SaveChangesAsync();

            return "Update - Balance";
        }
    }
}
