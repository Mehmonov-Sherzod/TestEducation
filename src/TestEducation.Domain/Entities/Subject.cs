using TestEducation.Domain.Entities;

namespace TestEducation.Models
{
    public class Subject
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public List<SubjectTranslate> SubjectTranslates { get; set; }
    }
}
