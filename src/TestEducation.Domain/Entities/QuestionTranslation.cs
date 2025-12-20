using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Domain.Enums;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public  class QuestionTranslation
    {
        public Guid Id { get; set; } 

        public Question Question { get; set; }

        public Guid QuestionId { get; set; }

        public Language LanguageId { get; set; }

        public string ColumnName { get; set; }

        public string TranslateText { get; set; }
    }
}
