using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models.BalanceTransaction;
using TestEducation.Data;

namespace TestEducation.Aplication.Service.Impl
{
    public class BalanceTransactionService : IBalanceTransactionService
    {
        private readonly AppDbContext _appDbContext;

        public BalanceTransactionService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public async Task<BalanceTransactionResponce> GetBalanceTransaction()
        {
            var BalanceTransaction = await _appDbContext.BalanceTransactions
                .Select(x => new BalanceTransactionResponce
                {
                    Id = x.Id,
                    CardNumber = x.CardNumber,
                    FullName = x.FullName,
                    UserAdmin = x.UserAdmin,
                }).FirstAsync();

            return BalanceTransaction;
        }

        public async Task<string> UpdateBalanceTransaction(BalanceTransactionUpdate balanceTransactionUpdate, Guid Id)
        {
            var Balance = await _appDbContext.BalanceTransactions
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (Balance == null)
                throw new NotFoundException("Balance Topilmadi");


            Balance.CardNumber = balanceTransactionUpdate.CardNumber;
            Balance.FullName = balanceTransactionUpdate.FullName;
            Balance.UserAdmin = balanceTransactionUpdate.UserAdmin;

            _appDbContext.BalanceTransactions.Update(Balance);
            await _appDbContext.SaveChangesAsync();

            return "Update - Balance";

        }
    }
}
