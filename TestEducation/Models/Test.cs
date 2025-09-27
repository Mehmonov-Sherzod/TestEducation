using System.Net.Sockets;
using TestEducation.Models;

namespace TestEducation.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int subjectId { get; set; }
        public Subject Subject { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public List<UserTest> userTests { get; set; }


    }
}

