using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public  class SharedSource
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string? Path { get; set; }

        public Guid SubjectId { get; set; }  

        public Subject Subject { get; set; }    
    }
}
