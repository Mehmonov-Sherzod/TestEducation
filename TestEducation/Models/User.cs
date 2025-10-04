namespace TestEducation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }     
        public string Salt { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;
        public List<UserQuestion> userQuestions   { get; set; }     
        public List<UserRole> UserRoles { get; set; }
    }
}
