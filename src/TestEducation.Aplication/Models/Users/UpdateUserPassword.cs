using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.Users
{
    public class UpdateUserPassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class UpdateUserPasswordResponseModel : BaseResponseModel;
}
