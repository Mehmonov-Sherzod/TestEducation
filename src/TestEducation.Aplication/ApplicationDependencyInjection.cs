using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestEducation.Data;
using TestEducation.Service;
using TestEducation.Service.FileStoreageService;
using TestEducation.Service.QuestionAnswerService;
using TestEducation.Service.SubjectService;
using TestEducation.Service.UserService;

namespace TestEducation.Aplication
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<JwtService>();
            services.AddScoped<AppDbContext>();
            services.AddScoped<ISubjectServise, SubjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
            services.AddScoped<IFileStoreageService, MinioFileStorageService>();
            services.AddScoped<PasswordHelper>();
        }
    }
}
