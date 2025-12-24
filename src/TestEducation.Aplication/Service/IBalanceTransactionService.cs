using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.BalanceTransaction;

namespace TestEducation.Aplication.Service
{
    public interface IBalanceTransactionService
    {
        Task<BalanceTransactionResponce> GetBalanceTransaction();

        Task<string> UpdateBalanceTransaction(BalanceTransactionUpdate balanceTransactionUpdate, Guid Id);
    }
}
