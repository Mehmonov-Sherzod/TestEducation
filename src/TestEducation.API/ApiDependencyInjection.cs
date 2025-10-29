using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TestEducation.Aplication.Helpers.GenerateJwt;

namespace TestEducation.API;

public static class ApiDependencyInjection
{
    public static void AddJwtAuth(this IServiceCollection service, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("JwtOption").Get<JwtOption>();

        if (jwtOptions == null)
        {
            throw new InvalidOperationException("JWT sozlamalari topilmadi. appsettings.json faylida 'JwtOption' bo'limini tekshiring.");
        }


        service.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
        AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),

            };
        });
    }

    public static void AddSwagger(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddSwaggerGen(c =>
        {
            // JWT security schema
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Tokenni shu formatda kiriting: Bearer {your JWT token}"
            });

            // Authentication’ni Swagger’da yoqish
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
        });

    }
}
