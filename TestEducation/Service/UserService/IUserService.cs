using TestEducation.Dtos;

namespace TestEducation.Service.UserService
{
    public interface IUserService
    {
        Task<string> CreateUser(UserDTO userDTO);

        Task<ICollection<UserDTO>> GetAllUsers();

        Task<UserDTO> GetByIdUser(int id);

        Task<string> UpdateUser(int id, UserDTO userDTO);

        Task<string> DeleteByIdUser(int id);
    }
}
