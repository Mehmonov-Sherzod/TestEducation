using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.Users
{
    public class UserEmailReset
    {
        public string OtpCode { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

    }
}
