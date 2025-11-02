using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
namespace TestEducation.Service.UserService
{
    public interface IUserService
    {
        Task<CreateUserResponseModel> CreateUser(CreateUserModel userDTO);
        Task<List<UserResponseModel>> GetAllUsers();
        Task<UserResponseModel> GetByIdUser(int id);
        Task<UpdateUserResponseModel> UpdateUser(int id, UpdateUserModel userDTO);
        Task<string> DeleteByIdUser(int id);
        Task<PaginationResult<CreateUserModel>> CreateUserPage(PageOption model);
        Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
        Task<List<string>> GetUserPermission(int Id);
        Task<CreateAdminResponseModel> AdminCreateUserAsync(CreateUserByAdminModel createUserByAdminModel);
        Task<UpdateUserPasswordResponseModel> UpdateUserPassword(UpdateUserPassword password, int Id);
        Task<string> VerifyOtpAsync(OtpVerificationModel model);
    }
}
