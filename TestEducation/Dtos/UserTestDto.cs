namespace TestEducation.Dtos
{
    public class UserTestDto
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
