using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Data;
using TestEducation.Domain.Entities;

namespace TestEducation.Aplication.Service.Impl
{
    public class BoughtSourceBuyService : IBoughtSourceBuyService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _Httpcontext;

        public BoughtSourceBuyService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _Httpcontext = httpContextAccessor;
        }
        public async Task<string> ShareSouceBuy(Guid SharedSourceId)
        {
            var id = Guid.Parse(_Httpcontext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var User = await _appDbContext.Users
                .Include(x => x.UserBalance)
                .Include(x => x.UserSharedSources)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();


            var userbook = User.UserSharedSources
                .Where(x => x.SourceId == SharedSourceId)
                .FirstOrDefault();

            if (userbook != null)
                throw new BadHttpRequestException("bu kitob sotib olingan");

            var ShareBook = await _appDbContext.SharedSources
                .Where(x => x.Id == SharedSourceId)
                .FirstOrDefaultAsync();

            if(User.UserBalance.Amout >= ShareBook.Price)
            {
                User.UserBalance.Amout-=ShareBook.Price;

                UserSharedSource UserBook = new UserSharedSource
                {
                    Description = ShareBook.Description,
                    Path = ShareBook.Path,
                    UserId = User.Id,
                    SourceId = ShareBook.Id
                };

                _appDbContext.UserSharedSources.Add(UserBook);
                _appDbContext.SaveChangesAsync();
            }

            if (User.UserBalance.Amout < ShareBook.Price)
            {
                throw new Exception("Hisobingizda Mablag' Yetarli Emas");
            }


            return "Kitob Muvofaqiyatli Sotib Olindi";


        }
    }
}
