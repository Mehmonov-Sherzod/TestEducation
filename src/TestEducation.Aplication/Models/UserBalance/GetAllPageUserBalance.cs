using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.UserBalance
{
    public class GetAllPageUserBalance
    {
        public Guid Id { get; set; }
        public decimal Amout { get; set; }

        public string BalanceCode { get; set; }

        public string FullName { get; set; }
    }
}
