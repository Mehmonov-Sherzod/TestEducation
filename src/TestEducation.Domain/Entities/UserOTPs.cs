using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public class UserOTPs
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiredAt { get; set; }
        public User User { get; set; } = null!;
    }
}
