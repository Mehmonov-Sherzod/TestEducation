namespace TestEducation.Aplication.Models.Users
{
    public class LoginUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; } = new();
        public List<string> Permissions { get; set; } = new();

    }

}
