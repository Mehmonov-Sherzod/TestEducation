using Microsoft.EntityFrameworkCore;
using TestEducation.Data;
using TestEducation.Domain.Entities;

namespace TestEducation.Aplication.Service.Impl
{
    public class OtpService : IOtpService
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OtpService(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<string> GenerateAndSaveOtpAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var otpCode = new Random().Next(100000, 999999).ToString();

            var otp = new UserOTPs
            {
                UserId = userId,
                Code = otpCode,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMinutes(5)
            };

            await _context.userOTPs.AddAsync(otp);
            await _context.SaveChangesAsync();

            return otpCode;
        }

        public async Task<UserOTPs?> GetLatestOtpAsync(Guid userId, string code)
        {
            return await _context.userOTPs
                .Where(o => o.UserId == userId && o.Code == code && o.ExpiredAt > DateTime.UtcNow)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }
    }
}
