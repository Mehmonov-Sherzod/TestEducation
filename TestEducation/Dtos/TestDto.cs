namespace TestEducation.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int SubjectId { get; set; }
    }

    public class TestCreateDto
    {
        public string Title { get; set; } = null!;
        public int SubjectId { get; set; }
    }
}
