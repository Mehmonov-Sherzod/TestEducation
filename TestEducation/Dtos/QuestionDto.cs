using TestEducation.Models.Enums;

namespace TestEducation.Dtos
{
    public class QuestionDTO
    {
        public string QuestionText { get; set; }
        public int SubjectId { get; set; }
        public IFormFile? Image { get; set; }
        public QuestionLevel Level { get; set; }
        public List<AnswerDTO> Answers { get; set; } 
    }

}
