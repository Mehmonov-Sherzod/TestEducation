using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Domain.Entities;

namespace TestEducation.Aplication.Service
{
    public interface IOtpService
    {
        Task<string> GenerateAndSaveOtpAsync(int userId);
        Task<UserOTPs?> GetLatestOtpAsync(int userId, string code);
    }
}
