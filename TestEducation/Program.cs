using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TestEducation.Data;
using TestEducation.Models;
using TestEducation.Models.Enum;
using TestEducation.Service;
using TestEducation.Service.QuestionAnswerService;
using TestEducation.Service.QuestionLevelService;
using TestEducation.Service.SubjectService;
using TestEducation.Service.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<ISubjectServise, SubjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuestionLevelService, QuestionLevelService>();
builder.Services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
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

builder.Services.AddAuthorization();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
        if (!context.permissions.Any(x => x.Name == perm.Name))
            context.permissions.Add(perm);
    }

    context.SaveChanges();

    List<int> role = context.roles.Select(x => x.Id).ToList();
    List<int> Permissions = context.permissions.Select(x => x.Id).ToList();
    HashSet<int> RolePermission = context.rolePermissions.Select(x => x.RoleId).ToHashSet();

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

                    context.rolePermissions.Add(rolePermission);

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

                        context.rolePermissions.Add(rolePermission);
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

app.MapControllers();

app.Run();
