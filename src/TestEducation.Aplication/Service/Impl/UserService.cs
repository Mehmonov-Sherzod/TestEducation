using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Helpers.PasswordHashers;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.UserEmail;
using TestEducation.Aplication.Models.Users;
using TestEducation.Aplication.Service;
using TestEducation.Data;
using TestEducation.Models;

namespace TestEducation.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly PasswordHelper passwordHelper;
        private readonly JwtService _jwtService;
        private readonly VerifyPassword _verifyPassword;
        private readonly IOtpService _otpService;
        private readonly IEmailService _emailService;
        private readonly UserLogiPassword _userLogiPassword;

        public UserService(AppDbContext appDbContext,
            PasswordHelper passwordHelper,
            JwtService jwtService,
            VerifyPassword verifyPassword,
            IOtpService otpService,
            IEmailService emailService,
            UserLogiPassword userLogiPassword)
        {
            _appDbContext = appDbContext;
            this.passwordHelper = passwordHelper;
            _jwtService = jwtService;
            _verifyPassword = verifyPassword;
            _otpService = otpService;
            _emailService = emailService;
            _userLogiPassword = userLogiPassword;
        }
        public async Task<CreateUserResponseModel> CreateUser(CreateUserModel userDTO)
        {
            var users = await _appDbContext.Users.AnyAsync(x => x.Email == userDTO.Email);

            if (users)
                throw new BadRequestException("Bunday email bilan foydalanuvchi allaqachon mavjud");

            string salt = Guid.NewGuid().ToString();
            var hashPass = passwordHelper.Encrypt(userDTO.Password, salt);

            var user = new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                Password = hashPass,
                PhoneNumber = userDTO.PhoneNumber,
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
                    PhoneNumber = x.PhoneNumber,
                    

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
                         PhoneNumber = x.PhoneNumber,

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
            user.PhoneNumber = userDTO.PhoneNumber;

            await _appDbContext.SaveChangesAsync();

            return new UpdateUserResponseModel
            {
                Id = user.Id,
            };
        }

        public async Task<string> DeleteByIdUser(int id)
        {
            var user = await _appDbContext.Users
                        .Include(u => u.UserRoles)
                        .ThenInclude(ur => ur.Role)
                        .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new NotFoundException("Foydalanuvchi topilmadi.");

            bool isSuperAdmin = user.UserRoles.Any(x => x.Role.Name == "SuperAdmin");

            if (isSuperAdmin)
                throw new BadRequestException("SuperAdmin foydalanuvchisini o‘chirish mumkin emas");

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return "Foydalanuvchi o‘chirildi.";
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
                    PhoneNumber = x.PhoneNumber,
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
            {

                throw new NotFoundException("Username or Email is incorrect");
            }

            if (!passwordHelper.Verify(loginUserModel.Password, user.Salt, user.Password))
            {
                _userLogiPassword.Count++;

                if (_userLogiPassword.Count >= 5)
                {
                    _userLogiPassword.DataLogin = DateTime.Now.AddMinutes(5);
                    throw new BadRequestException("5 minutdan keyin urunib koring");
                }

                throw new BadRequestException("Email or Password not correct");
            }



            string token = _jwtService.GenerateToken(user);

            return new LoginResponseModel
            {
                Username = user.FullName,
                Email = user.Email,
                Token = token,
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

        public async Task<CreateAdminResponseModel> AdminCreateUserAsync(CreateUserByAdminModel createUserByAdmin)
        {
            var users = await _appDbContext.Users
                .Include(x => x.UserRoles)
                .AnyAsync(e => e.Email == createUserByAdmin.Email);

            string salt = Guid.NewGuid().ToString();
            var hashPass = passwordHelper.Encrypt(createUserByAdmin.Password, salt);

            var user = new User
            {
                FullName = createUserByAdmin.FullName,
                Email = createUserByAdmin.Email,
                Password = hashPass,
                PhoneNumber = createUserByAdmin.PhoneNumber,
                Salt = salt
            };

            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            foreach (var RoleId in createUserByAdmin.RoleIds)
            {
                UserRole userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = RoleId,
                };

                _appDbContext.UserRoles.Add(userRole);
            }
            await _appDbContext.SaveChangesAsync();

            return new CreateAdminResponseModel
            {
                Id = user.Id,
            };
        }

        public async Task<UpdateUserPasswordResponseModel> ResetPassword(UpdateUserPassword password, int Id)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (_verifyPassword.Verify(password.OldPassword, user.Salt, user.Password))
            {
                user.Password = passwordHelper.Encrypt(password.NewPassword, user.Salt);

                _appDbContext.Update(user);
                _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new BadRequestException("Eski Parol Hato");
            }

            return new UpdateUserPasswordResponseModel
            {
                Id = user.Id,
            };
        }

        public async Task<string> VerifyOtpAsync(OtpVerificationModel model)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
                throw new BadRequestException("Foydalanuvchi topilmadi.");

            var otp = await _otpService.GetLatestOtpAsync(user.Id, model.Code);
            if (otp is null || otp.ExpiredAt < DateTime.Now)
                throw new BadRequestException("Kod noto‘g‘ri yoki muddati tugagan.");

            user.IsVerified = true;
            await _appDbContext.SaveChangesAsync();

            return "OTP muvaffaqiyatli tasdiqlandi.";
        }

        public async Task<bool> SendOtpByEmail(UserEmailForgot userEmailForgot)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == userEmailForgot.Email);

            if (user == null)
                throw new BadRequestException(" Bunday email biln Foydalanuvchi topilmadi.");

            var otp = await _otpService.GenerateAndSaveOtpAsync(user.Id);

            _emailService.SendOtpAsync(user.Email, otp);

            return true;
        }

        public async Task<string> ForgotPassword(UserEmailReset userEmailReset)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == userEmailReset.Email);

            if (user == null)
                throw new BadRequestException(" Bunday email biln Foydalanuvchi topilmadi.");

            var UserOtp = await _appDbContext.userOTPs
                .Where(x => x.Code == userEmailReset.OtpCode)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();

            if (UserOtp.ExpiredAt < DateTime.UtcNow)
                throw new BadRequestException("Muddati tugagan");

            user.Password = passwordHelper.Encrypt(userEmailReset.NewPassword, user.Salt);

            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();

            return "Parol O'zgardi";
        }

    }
}