using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Domain.Enums;

namespace TestEducation.Aplication.Models.Subject
{
    public class UpdateSubjectTranslateModel
    {
        public int Id { get; set; }
        public Language LanguageId { get; set; }

        public string ColumnName { get; set; }

        public string TranslateText { get; set; }
    }
}
