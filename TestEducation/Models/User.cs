namespace TestEducation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }  
        public List<UserTest> Tests { get; set; }   
        public List<UserRole> UserRoles { get; set; }
    }
}
