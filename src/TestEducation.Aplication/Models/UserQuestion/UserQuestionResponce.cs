using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.UserQuestionAnswer;

namespace TestEducation.Aplication.Models.UserQuestion
{
    public class UserQuestionResponce
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public Guid TextProcessId { get; set; }
        public List<UserQuestionAnswerResponce> UserQuestionAnswers { get; set; }
    }
}
