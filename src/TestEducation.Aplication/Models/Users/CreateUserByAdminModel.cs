using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.Users
{
    public class CreateUserByAdminModel
    {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public List<int> RoleIds { get; set; }
    }
    public class CreateAdminResponseModel : BaseResponseModel;
}
