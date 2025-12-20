using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.Subject;

namespace TestEducation.Aplication.Models.Topic
{
    public class CreateTopicModel
    {
        public string TopicName { get; set; }
        public Guid SubjectId    { get; set; }
    }

    public class CreateTopicResponseModel
    {
        public Guid Id { get; set; }
    }
}
