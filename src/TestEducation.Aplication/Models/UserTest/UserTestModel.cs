using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TestEducation.Aplication.Models.Test;
using TestEducation.Aplication.Models.UserQuestion;

namespace TestEducation.Aplication.Models.UserTest
{
    public class UserTestModel
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public User User { get; set; }
        public TestResponseModel test { get; set; }
        public List<UserQuestionModel> UserQuestions { get; set; }
    }
}
