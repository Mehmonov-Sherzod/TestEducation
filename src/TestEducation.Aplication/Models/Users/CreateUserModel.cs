namespace TestEducation.Aplication.Models.Users
{
    public class CreateUserModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreateUserResponseModel : BaseResponseModel;
}
