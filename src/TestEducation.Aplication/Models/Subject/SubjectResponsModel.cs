using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.Subject
{
    public class SubjectResponsModel
    {
        public Guid Id { get; set; }

        public string SubjectName { get; set; }

        public List<SubjectTranslateResponseModel> Translates { get; set; }
    }
}
