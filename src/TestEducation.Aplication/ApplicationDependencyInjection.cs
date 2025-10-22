using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minio;
using TestEducation.Aplication.Common;
using TestEducation.Aplication.Service;
using TestEducation.Aplication.Service.Impl;
using TestEducation.Aplication.Validators.QuestionValidator;
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
            services.AddSingleton<IRabbitMQproducer, RabbitMQProducer>();
            services.AddScoped<QuestionCreateValidator>();
           // services.AddHostedService<RabbitMQConsumer>();



            services.AddSingleton<IMinioClient>(sp =>
            {
                var minioSettings = sp.GetRequiredService<IOptions<MinioSettings>>().Value;

                // MinioClient obyektini yaratish
                var client = new MinioClient()
                    .WithEndpoint(minioSettings.Endpoint)
                    .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey);

                // Agar SSL yoqilgan bo'lsa
                if (minioSettings.UseSsl)
                {
                    client = client.WithSSL();
                }
                return client.Build(); // MinioClient ni qurish
            });
        }


    }
}
