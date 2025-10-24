using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestEducation.Domain.Entities
{
    public class UserTest
    {
        public int Id { get; set; }  
        public int UserId { get; set; }  
        public int TestId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }
        public List<UserQuestion> UserQuestions { get; set; }  
    }
}
