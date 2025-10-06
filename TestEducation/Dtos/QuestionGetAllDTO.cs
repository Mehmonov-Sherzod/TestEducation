namespace TestEducation.Dtos
{
    public class QuestionGetAllDTO
    {
        public string QuestionText { get; set; }
        public string Image { get; set; }
        public List<AnswerGetAllDTO> Answers { get; set; } 
    }
}
