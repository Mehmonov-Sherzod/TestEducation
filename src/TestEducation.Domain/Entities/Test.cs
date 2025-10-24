using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }         
        public string Name { get; set; }      
        public int SubjectId { get; set; }  
        public Subject Subject { get; set; }  
        public int DurationMinutes { get; set; }  

        public List<Question> Questions { get; set; }

        // Foydalanuvchining test sessiyalari
        public List<UserTest> UserTests { get; set; }
    }
}
