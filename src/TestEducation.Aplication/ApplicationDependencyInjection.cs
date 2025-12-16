using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minio;
using TestEducation.Aplication.Common;
using TestEducation.Aplication.Helpers.PasswordHashers;
using TestEducation.Aplication.Models.Question;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Aplication.Models.Users;
using TestEducation.Aplication.Service;
using TestEducation.Aplication.Service.Impl;
using TestEducation.Aplication.Validators.QuestionValidator;
using TestEducation.Aplication.Validators.SubjectValidator;
using TestEducation.Aplication.Validators.UserValidatoe;
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
            services.Configure<MinioSettings>(configuration.GetSection("MinioSettings"));
            services.AddValidators();
            services.AddServices(configuration);
            return services;
        }
        private static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<JwtService>();
            services.AddScoped<AppDbContext>();
            services.AddScoped<ISubjectServise, SubjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
            services.AddScoped<PasswordHelper>();
            services.AddScoped<VerifyPassword>();
            services.AddSingleton<IRabbitMQproducer, RabbitMQProducer>();
            services.AddScoped<QuestionCreateValidator>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddHttpContextAccessor();


            var minioSettings = configuration.GetSection("MinioSettings").Get<MinioSettings>();

            if (minioSettings == null)
                throw new Exception("MinioSettings section is missing from configuration.");

            // Register MinioSettings as singleton
            services.AddSingleton(minioSettings);

            services.AddScoped<IFileStoreageService, MinioFileStorageService>();


            // Register MinioClient
            services.AddSingleton<IMinioClient>(sp =>
            {
                var client = new MinioClient()
                    .WithEndpoint(minioSettings.Endpoint)
                    .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey);

                if (minioSettings.UseSsl)
                {
                    client = client.WithSSL();
                }

                return client.Build();
            });
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateQuestionModel>, QuestionCreateValidator>();
            services.AddScoped<IValidator<CreateUserModel>, UserCreateValidator>();
            services.AddScoped<IValidator<CreateSubjectModel>, SubjectCreateValidator>();

            return services;
        }
    }
}
