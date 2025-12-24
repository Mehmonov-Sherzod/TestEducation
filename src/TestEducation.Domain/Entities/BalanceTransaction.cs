using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Domain.Entities
{
    public class BalanceTransaction
    {
        public Guid Id { get; set; }

        public string CardNumber { get; set; }

        public string UserAdmin { get; set; }

        public string FullName { get; set; }
    }
}
