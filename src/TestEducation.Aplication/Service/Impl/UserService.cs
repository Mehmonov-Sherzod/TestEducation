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
        private readonly JwtService _jwtService;

        public UserService(AppDbContext appDbContext, PasswordHelper passwordHelper, JwtService jwtService)
        {
            _appDbContext = appDbContext;
            this.passwordHelper = passwordHelper;
            _jwtService = jwtService;
        }
        public async Task<CreateUserResponseModel> CreateUser(CreateUserModel userDTO)
        {
            var users = await _appDbContext.Users.AnyAsync(x => x.Email == userDTO.Email);

            if (users)
                throw new BadRequestException("Bunday email bilan foydalanuvchi allaqachon mavjud");

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
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            var studentRole = await _appDbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Student");
            if (studentRole != null)
            {
                var userRole = new UserRole

                {
                    UserId = user.Id,
                    RoleId = studentRole.Id
                };
                await _appDbContext.UserRoles.AddAsync(userRole);
                await _appDbContext.SaveChangesAsync();
            }

            return new CreateUserResponseModel
            {
                Id = user.Id,
            };

        }
        public async Task<List<UserResponseModel>> GetAllUsers()
        {
            var users = await _appDbContext.Users
                .Select(x => new UserResponseModel
                {
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,

                })
                .ToListAsync();

            if (users == null)
                throw new NotFoundException("Foydalanuvchilar topilmadi.");

            return users;
        }
        public async Task<UserResponseModel> GetByIdUser(int id)
        {
            var user = await _appDbContext.Users
                     .Where(x => x.Id == id)
                     .Select(x => new UserResponseModel
                     {
                         FullName = x.FullName,
                         Email = x.Email,
                         Password = x.Password,

                     })
                     .FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException("Foydalanuvchi topilmadi.");

            return user;
        }
        public async Task<UpdateUserResponseModel> UpdateUser(int id, UpdateUserModel userDTO)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("Foydalanuvchi topilmadi.");


            user.FullName = userDTO.FullName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;

            await _appDbContext.SaveChangesAsync();

            return new UpdateUserResponseModel
            {
                Id = user.Id,
            };
        }
        public async Task<string> DeleteByIdUser(int id)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("Foydalanuvchi topilmadi.");

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return "Malumot o'chirildi";
        }
        public async Task<PaginationResult<CreateUserModel>> CreateUserPage(PageOption model)
        {
            var query = _appDbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(s => s.FullName.Contains(model.Search));
            }
            Console.WriteLine(query.ToQueryString());
            List<CreateUserModel> User = await query
                .Skip(model.PageSize * (model.PageNumber - 1))
                .Take(model.PageSize)
                .Select(x => new CreateUserModel
                {
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,
                }).ToListAsync();

            int total = _appDbContext.Users.Count();

            return new PaginationResult<CreateUserModel>
            {
                Values = User,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                TotalCount = total
            };
        }
        public async Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel)
        {
            var user = await _appDbContext.Users
                .Include(x => x.UserRoles)
                  .ThenInclude(y => y.Role)
                     .ThenInclude(z => z.RolePermissions)
                        .ThenInclude(a => a.Permission)
                           .FirstOrDefaultAsync(u => u.Email == loginUserModel.Email);

            if (user == null)
                throw new NotFoundException("Username or Email is incorrect");

            if (!passwordHelper.Verify(loginUserModel.Password, user.Salt, user.Password))
                throw new BadRequestException("Email or Password not correct");

            string token = _jwtService.GenerateToken(user);

            return new LoginResponseModel
            {
                Username = user.FullName,
                Email = user.Email,
                Token = token,
                //Roles = user.UserRoles.Select(x => x.Role.Name).ToList(),
                //Permissions = user.UserRoles.SelectMany(y => y.Role.RolePermissions)
                //.Select(z => z.Permission.Name)
                //.ToList()
            };
        }
        public Task<List<string>> GetUserPermission(int Id)
        {
            return _appDbContext.UserRoles
                .Where(x => x.UserId == Id)
                .SelectMany(r => r.Role.RolePermissions)
                .Select(p => p.Permission.Name)
                .ToListAsync();
        }
    }
}