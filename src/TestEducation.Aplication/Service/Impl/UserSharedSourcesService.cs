using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.UserSharedSources;
using TestEducation.Data;

namespace TestEducation.Aplication.Service.Impl
{
    public class UserSharedSourcesService : IUserSharedSourcesService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _Httpcontext;

        public UserSharedSourcesService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;   
            _Httpcontext = httpContextAccessor;
        }


        public async Task<List<UserSharedSourcesResponce>> GetMySharedSource()
        {
            var id = Guid.Parse(_Httpcontext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Book = await _appDbContext.UserSharedSources
                .Where(x => x.User.Id == id)
                .Select(x => new UserSharedSourcesResponce
                {
                    Description = x.Description,
                    Path = x.Path,
                }).ToListAsync();

            return Book;
        }
    }
}
