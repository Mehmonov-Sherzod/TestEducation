using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.Domain.Entities
{
    public class UserSharedSource
    {
        public Guid Id  { get; set; }
        public string Description { get; set; }
        public string? Path { get; set; }   
        public Guid SourceId { get; set; }
        public User User { get; set; }  
        public Guid UserId { get; set; }    
    }
}
