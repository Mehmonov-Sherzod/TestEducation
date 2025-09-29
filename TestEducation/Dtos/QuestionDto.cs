using TestEducation.Models;

namespace TestEducation.Dtos
{
    public class QuestionDto
    {
        public string QuestionText { get; set; } 
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }    
        public List<AnswerOptionDto> Answers { get; set; }
    }

}
