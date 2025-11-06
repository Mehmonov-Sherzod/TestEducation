using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Aplication.Models.UserTest;

namespace TestEducation.Aplication.Models.Test
{
    public  class TestResponseModel
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int DurationMinutes { get; set; }
        public List<UserTestModel> UserTests { get; set; }
    }
}
