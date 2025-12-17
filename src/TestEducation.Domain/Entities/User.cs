using TestEducation.Domain.Entities;

namespace TestEducation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Salt { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiredAt { get; set; }
        public List<UserQuestion> userQuestions { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<TestProcess> TestProcesses { get; set; }
    }
}
