using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.UserBalance;

namespace TestEducation.Aplication.Service
{
    public interface IUserBalandeService
    {

        Task<GetMeUserBalance> GetMyBalance();

        Task<PaginationResult<GetAllPageUserBalance>> GetAllPageUserBalance(PageOption pageOption);

        Task<string> UpdateUserBalance(UpdateUserBalance updateUserBalance, Guid Id , decimal Amount);
    }
}
