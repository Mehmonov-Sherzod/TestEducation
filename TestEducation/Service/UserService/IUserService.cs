using TestEducation.Dtos;

namespace TestEducation.Service.UserService
{
    public interface IUserService
    {
        Task<ResponseDTO> CreateUser(UserDTO userDTO);

        Task<ResponseDTO<ICollection<UserDTO>>> GetAllUsers();

        Task<ResponseDTO<UserDTO>> GetByIdUser(int id);

        Task<ResponseDTO<UserDTO>> UpdateUser(int id, UserDTO userDTO);

        Task<ResponseDTO> DeleteByIdUser(int id);
    }
}
 