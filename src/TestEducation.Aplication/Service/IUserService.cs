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

        Task<PaginationResult<CreateUserModel>> CreateUserPage(UserPageModel model);
    }
}
 