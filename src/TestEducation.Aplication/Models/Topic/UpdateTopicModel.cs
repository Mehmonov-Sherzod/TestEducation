using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.Topic
{
    public class UpdateTopicModel
    {
        public string TopicName { get; set; }
    }

    public class UpdateTopicResponseModel
    {
        public Guid Id { get; set; }
    }
}
