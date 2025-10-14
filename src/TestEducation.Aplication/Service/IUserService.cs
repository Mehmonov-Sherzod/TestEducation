using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
namespace TestEducation.Service.UserService
{
    public interface IUserService
    {
        Task<ApiResult<string>> CreateUser(UserDTO userDTO);

        Task<ApiResult<ICollection<UserDTO>>> GetAllUsers();

        Task<ApiResult<UserDTO>> GetByIdUser(int id);

        Task<ApiResult<string>> UpdateUser(int id, UserDTO userDTO);

        Task<ApiResult<string> DeleteByIdUser(int id);
    }
}
 