namespace TestEducation.Dtos
{
    public class QuestionDTO
    {
        public string QuestionText { get; set; }
        public int SubjectId { get; set; }
        public List<AnswerOptionDto> Answers { get; set; }

      //  public QuestionLevelDto Level { get; set; }
    }

}
