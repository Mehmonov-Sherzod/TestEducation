using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;
using TestEducation.Data;
using TestEducation.Models;

namespace TestEducation.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        private readonly PasswordHelper passwordHelper;

        public UserService(AppDbContext appDbContext, PasswordHelper passwordHelper)
        {
            _appDbContext = appDbContext;
            this.passwordHelper = passwordHelper;
        }

        public async Task<ApiResult<string>> CreateUser(UserDTO userDTO)
        {
            if (await _appDbContext.users.AnyAsync(x => x.Email == userDTO.Email))
            {
                throw new BadRequestException("Bunday email bilan foydalanuvchi allaqachon mavjud");
            }


            string salt = Guid.NewGuid().ToString();
            var hashPass = passwordHelper.Incrypt(userDTO.Password, salt);

            var user = new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                Password = hashPass,
                CreatedAt = DateTime.UtcNow,
                Salt = salt

            };
            _appDbContext.users.Add(user);
            await _appDbContext.SaveChangesAsync();
            var studentRole = await _appDbContext.roles.FirstOrDefaultAsync(r => r.Name == "Student");
            if (studentRole != null)
            {
                var userRole = new UserRole

                {
                    UserId = user.Id,
                    RoleId = studentRole.Id
                };
                await _appDbContext.userRoles.AddAsync(userRole);
                await _appDbContext.SaveChangesAsync();
            }

            return ApiResult<string>.Success("User topildi");

        }

        public async Task<ApiResult<ICollection<UserDTO>>> GetAllUsers()
        {
            var users = await _appDbContext.users
                .Select(x => new UserDTO
                {
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,

                })
                .ToListAsync();

            if (users == null || users.Count == 0)
                throw new NotFoundException("Foydalanuvchilar topilmadi.");

            return ApiResult<ICollection<UserDTO>>.Success(users);
        }

        public async Task<ApiResult<UserDTO>> GetByIdUser(int id)
        {
            var user = await _appDbContext.users
         .Where(x => x.Id == id)
         .Select(x => new UserDTO
         {
             FullName = x.FullName,
             Email = x.Email,
             Password = x.Password,

         })
         .FirstOrDefaultAsync();

            if (user == null )
                throw new NotFoundException("Foydalanuvchi topilmadi.");


            return ApiResult<UserDTO>.Success(user);

        }


        public async Task<ApiResult<string>> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("Foydalanuvchi topilmadi.");

            user.FullName = userDTO.FullName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;

            await _appDbContext.SaveChangesAsync();

           return  ApiResult<string>.Success("Malumot o'zgardi");
        }


        public async Task<ApiResult<string> DeleteByIdUser(int id)
        {
            var user = await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("Foydalanuvchi topilmadi.");

            _appDbContext.users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return ApiResult<string>.Success("Malumot o'chirildi");
        }


    }
}