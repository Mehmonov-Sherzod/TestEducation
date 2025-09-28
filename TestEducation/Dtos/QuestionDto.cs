namespace TestEducation.Dtos
{
    public class QuestionDto
    {
        public string QuestionText { get; set; } 
        public int TestId { get; set; }
        public List<AnswerOptionDto> Answers { get; set; }
    }

}
