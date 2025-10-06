using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Dtos;
using TestEducation.Models;

namespace TestEducation.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        private readonly PasswordHelper passwordHelper;

        public UserService(AppDbContext appDbContext , PasswordHelper passwordHelper)
        {
            _appDbContext = appDbContext;
            this.passwordHelper = passwordHelper;
        }

        public async Task<ResponseDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            if (await _appDbContext.users.AnyAsync(x => x.Email == userDTO.Email))
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "bunday email ga ega user mavjud",
                    StatusCode = 400
                };
            }
            string salt = Guid.NewGuid().ToString();

            var hashPass = passwordHelper.Incrypt(userDTO.Password, salt);


            var user = new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                CreatedAt = DateTime.UtcNow,
                Salt = salt

            };

            _appDbContext.users.Add(user);
            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "user qoshildi",
                StatusCode = 201
            };
        }

        public async Task<ResponseDTO> DeleteByIdUser([FromQuery] int id)
        {
            var user = await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "bunday id li user mavjud emas",
                    StatusCode = 404
                };

            _appDbContext.users.Remove(user);
            await  _appDbContext.SaveChangesAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "foydalanuvchi ochirildi",
                StatusCode = 200
                
            };
        }

        public async Task<ResponseDTO<ICollection<UserDTO>>> GetAllUsers()

        {
            var users = await _appDbContext.users
                .Select(x => new UserDTO
                {
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,

                })
                .ToListAsync();

            return new ResponseDTO<ICollection<UserDTO>>
            {
                IsSuccess = true,
                Message = "Foydalanuvchilar ro'yxati olindi",
                StatusCode = 200,
                Data = users
            };
        }

        public async Task<ResponseDTO<UserDTO>> GetByIdUser(int id)
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

            if (user == null)
                return new ResponseDTO<UserDTO>
                {
                    IsSuccess = false,
                    Message = $"ID ga bo'lgan user topilmadi",
                    StatusCode = 404,
                    Data = null

                };
            

            return new ResponseDTO<UserDTO>
            {
                IsSuccess = true,
                Message = "User topildi",
                StatusCode = 200,
                Data = user
            };

        }

        public async Task<ResponseDTO<UserDTO>> UpdateUser(int id, UserDTO userDTO)
        {
           var user = await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return new ResponseDTO<UserDTO>
                {
                    IsSuccess = false,
                    Message = "bunday id ga ega bolgan user yo'q",
                    StatusCode = 404,
                    Data = null,
                };

            user.FullName = userDTO.FullName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;

            await _appDbContext.SaveChangesAsync();

            return new ResponseDTO<UserDTO>
            {
                IsSuccess = true,
                Message = "user qoshildi",
                StatusCode = 200,
                Data = userDTO

            };
        }
    }
}