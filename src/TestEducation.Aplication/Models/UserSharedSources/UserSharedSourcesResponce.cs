using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.UserSharedSources
{
    public class UserSharedSourcesResponce
    {
        public string Description { get; set; }
        public string? Path { get; set; }

        public Guid UserId { get; set; }
    }
}
