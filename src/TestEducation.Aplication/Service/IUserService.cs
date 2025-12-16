using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.UserEmail;
using TestEducation.Aplication.Models.Users;
using TestEducation.Models;
namespace TestEducation.Service.UserService
{
    public interface IUserService
    {
        Task<CreateUserResponseModel> CreateUser(CreateUserModel userDTO);
        Task<UserResponseModel> GetByIdUser(int id);
        Task<UpdateUserResponseModel> UpdateUser(UpdateUserModel userDTO);
        Task<string> DeleteByIdUser(int id);
        Task<PaginationResult<UserResponseModel>> CreateUserPage(PageOption model);
        Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
        Task<CreateAdminResponseModel> AdminCreateUserAsync(CreateUserByAdminModel createUserByAdminModel);
        Task<UpdateUserPasswordResponseModel> ResetPassword(UpdateUserPassword password);
        Task<string> VerifyOtpAsync(OtpVerificationModel model);
        Task<bool> SendOtpByEmail(UserEmailForgot userEmailForgot);
        Task<string> ForgotPassword(UserEmailReset userEmailReset);


    }
}

