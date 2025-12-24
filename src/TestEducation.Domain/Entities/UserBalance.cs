using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public  class UserBalance
    {
        public Guid Id { get; set; }

        public decimal Amout { get; set; }  

        public string BalanceCode { get; set; } 

        public User User { get; set; }  

        public Guid UserId { get; set; }    
    }
}
