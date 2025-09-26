namespace TestEducation.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int TestId { get; set; }
        public int LevelId { get; set; }
    }

    public class QuestionCreateDto
    {
        public string Text { get; set; } = null!;
        public int TestId { get; set; }
        public int LevelId { get; set; }
    }
}
