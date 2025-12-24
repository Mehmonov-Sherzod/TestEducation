using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Features;
using Telegram.Bot;
using TestEducation.API;
using TestEducation.API.Filter;
using TestEducation.API.Middleware;
using TestEducation.Aplication;
using TestEducation.Aplication.Common;
using TestEducation.Aplication.Helpers.GenerateJwt;
using TestEducation.Aplication.Helpers.SeedData;
using TestEducation.Aplication.Service.Impl;
using TestEducation.DataAcces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers(config => config.Filters.Add(typeof(ValidateModelAttribute)))
    .AddJsonOptions(options =>
    {
        // Use PascalCase for JSON property names to match frontend expectations
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddResponseCaching(); // Responce cashe
builder.Services.AddOutputCache(); // OutputCach cashe

builder.Services.AddFluentValidationAutoValidation();

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOption"));
builder.Services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSwagger(builder.Configuration);

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 52428800; // 50 MB
});

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<TestEducation.Aplication.AddRequiredHeaderParameter>();
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


var supportedCultures = new[] { "en-US", "uz-Latn-UZ", "ru-RU" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("uz-Latn-UZ")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy
            .WithOrigins(
                "http://10.30.13.228:3000",
                "http://10.30.13.228",
                "https://10.30.13.228",
                "http://localhost:3000"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RolePermissionSeeder>();
    context.SeedMapping();
}

app.UseCors("AllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching(); // Responce cashe Middlware 
app.UseOutputCache(); // OutputCache Middlware 

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
