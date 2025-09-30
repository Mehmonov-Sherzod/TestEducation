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
                UserRoles = userDTO.Roles.Select(x => new UserRole
                {
                    RoleId = x.RoleId
                }).ToList()
            };

            _appDbContext.users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return "user qowildi";
        }

        public async Task<string> DeleteByIdUser(int id)
        {
            var user = await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return "user topilmadi";

            _appDbContext.users.Remove(user);
            await  _appDbContext.SaveChangesAsync();

            return "user ochirildi";
        }

        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var users = await _appDbContext.users.Select(x => new UserDTO
            {
                FullName = x.FullName,
                Email = x.Email,
                Password = x.Password,
                IsActive = x.IsActive,
                CreatedAt = DateTime.UtcNow,
            
            }).ToListAsync();

            return users;
        }

        public async Task<UserDTO> GetByIdUser(int id)
        {
            var user = await _appDbContext.users.
                Where(x => x.Id == id)
                .Select(x => new UserDTO
                {
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,
                    IsActive = x.IsActive,
                    CreatedAt = DateTime.UtcNow,
                }).FirstOrDefaultAsync();

            return user;


        }
        public async Task<UserDTO> UpdateUser(int id , UserDTO userDTO)
        {
            var user = await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            user.FullName = userDTO.FullName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.IsActive = userDTO.IsActive;
            user.CreatedAt = DateTime.UtcNow;

            await _appDbContext.SaveChangesAsync();

            return new UserDTO
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                IsActive = user.IsActive,
                CreatedAt = DateTime.UtcNow,
            };
        }

      
    }
}
