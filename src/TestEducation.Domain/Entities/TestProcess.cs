using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public  class TestProcess
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public int TotalQuestions { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? IncorrectAnswers { get; set; }
        public float? PercentageOfCorrectAnswers { get; set; }
        public double TotalScore { get; set; }
        public bool IsFinished { get; set; }
        public User User { get; set; }
        public List<UserQuestion> UserQuestions { get; set; }
    }
}
