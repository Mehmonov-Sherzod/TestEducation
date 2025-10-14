using TestEducation.Aplication.Models.Answer;

namespace TestEducation.Aplication.Models.Question
{
    public class QuestionUpdateDTO
    {
        public string QuestionText { get; set; }

        public List<AnswerDTO> Answers { get; set; } 
    }
}
