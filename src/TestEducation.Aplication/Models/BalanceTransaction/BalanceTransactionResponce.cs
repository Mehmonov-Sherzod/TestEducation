using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.BalanceTransaction
{
    public  class BalanceTransactionResponce
    {
        public Guid Id { get; set; }

        public string CardNumber { get; set; }

        public string UserAdmin { get; set; }

        public string FullName { get; set; }
    }
}
