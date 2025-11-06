namespace TestEducation.Aplication.Models.Users
{
    public class UpdateUserModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }

    public class UpdateUserResponseModel : BaseResponseModel;
}
