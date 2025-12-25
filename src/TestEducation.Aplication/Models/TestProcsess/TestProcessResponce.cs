using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.UserQuestion;

namespace TestEducation.Aplication.Models.TestProcsess
{
    public class TestProcessResponce
    {
        public Guid Id { get; set; }    
        public Guid UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public List<UserQuestionResponce> UserQuestions { get; set; }

    }
}
