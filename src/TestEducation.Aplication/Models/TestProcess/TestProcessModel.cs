using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.UserQuestion;

namespace TestEducation.Aplication.Models.TestProcess
{
    public class TestProcessModel
    {
        public int UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public int TotalQuestions { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? IncorrectAnswers { get; set; }
        public float? PercentageOfCorrectAnswers { get; set; }
        public double TotalScore { get; set; }
        public List<UserQuestionModel> UserQuestions { get; set; }

    }
}
