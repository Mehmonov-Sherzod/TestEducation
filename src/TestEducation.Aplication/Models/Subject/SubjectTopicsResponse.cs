using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.Topic;

namespace TestEducation.Aplication.Models.Subject
{
    public class SubjectTopicsResponse
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<TopicResponseModel> Topics { get; set; }
    }
}
