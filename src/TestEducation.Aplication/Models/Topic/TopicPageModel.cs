using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.Topic
{
    public class TopicPageModel
    {
        public Guid SubjectId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; } = "";
    }
}
