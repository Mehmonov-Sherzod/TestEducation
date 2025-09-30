namespace TestEducation.Dtos
{
    public class QuestionDTO
    {
        public string QuestionText { get; set; }
        public int SubjectId { get; set; }
        public int QuestionLevelId { get; set; }    
        public List<AnswerDTO> Answers { get; set; } 
    }

}
