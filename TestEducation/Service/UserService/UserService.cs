using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;

namespace TestEducation.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> CreateUser(UserDTO userDTO)
        {
           var rezult = await _appDbContext.users.AnyAsync(x => x.Email == userDTO.Email);

            if (rezult)
                return "Bunday emailga ega bolgan user mavjud";

            var user = new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                IsActive = userDTO.IsActive,
                CreatedAt = DateTime.UtcNow,
            }

        }

        public Task<string> DeleteByIdUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDTO>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByIdUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateUser(int id, UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
