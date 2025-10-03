namespace TestEducation.Dtos
{
    public class QuestionUpdateDTO
    {
        public string QuestionText { get; set; }

        public List<AnswerDTO> Answers { get; set; } 
    }
}
