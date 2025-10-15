using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Minio;
using TestEducation.API.Middleware;
using TestEducation.Aplication.Common;
using TestEducation.Data;
using TestEducation.Domain.Enums;
using TestEducation.Models;
using TestEducation.Service;
using TestEducation.Service.FileStoreageService;
using TestEducation.Service.QuestionAnswerService;
using TestEducation.Service.SubjectService;
using TestEducation.Service.UserService;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<ISubjectServise, SubjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
builder.Services.AddScoped<IFileStoreageService, MinioFileStorageService>();
builder.Services.AddScoped<PasswordHelper>();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };


    });


// api da enum tipini string qilish uchun

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAuthorization();
builder.Services.Configure<MinioSettings>(configuration.GetSection("MinioSettings"));

builder.Services.AddSingleton<IMinioClient>(sp =>
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




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", policy =>
    {
        policy.AllowAnyOrigin()

        .AllowAnyMethod()


        .AllowAnyHeader();

    });

    options.AddPolicy("StrictCorsPolicy", policy =>
    {
        policy.WithOrigins(

            ""

            )

        .WithMethods("GET", "POST", "put", "delete")

        .WithHeaders("Content - type", "Authorization")

        .AllowCredentials();
    });
});

var app = builder.Build();


app.UseCors("StrictCorsPolicy");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var permissions = Enum.GetValues(typeof(PermissionEnum))
        .Cast<PermissionEnum>()
        .Select(p => new Permission
        {
            Name = p.ToString(),
            Description = p + " permission"
        }).ToList();

    foreach (var perm in permissions)
    {
        if (!context.Permissions.Any(x => x.Name == perm.Name))
            context.Permissions.Add(perm);
    }

    context.SaveChanges();

    List<int> role = context.Roles.Select(x => x.Id).ToList();
    List<int> Permissions = context.Permissions.Select(x => x.Id).ToList();
    HashSet<int> RolePermission = context.RolePermissions.Select(x => x.RoleId).ToHashSet();

    foreach (var roles in role)
    {
        if (!RolePermission.Contains(roles))
        {
            if (roles == 1)
            {
                foreach (var permission in Permissions)
                {
                    RolePermission rolePermission = new RolePermission
                    {
                        RoleId = roles,
                        PermissionId = permission,
                    };

                    context.RolePermissions.Add(rolePermission);

                }
            }

            if (roles == 2)
            {

                foreach (var permission in Permissions)
                {
                    if (permission >= 6 && permission <= 9)
                    {
                        RolePermission rolePermission = new RolePermission
                        {
                            RoleId = roles,
                            PermissionId = permission,
                        };

                        context.RolePermissions.Add(rolePermission);
                    }

                }
            }
        }
    }

    context.SaveChanges();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
