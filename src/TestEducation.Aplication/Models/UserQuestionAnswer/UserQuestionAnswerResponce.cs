using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.UserQuestionAnswer
{
    public class UserQuestionAnswerResponce
    {
        public Guid Id { get; set; }
        public Guid UserQuestionId { get; set; }
        public bool IsMarked { get; set; } = false;
        public string AnswerText { get; set; }

    }
}
