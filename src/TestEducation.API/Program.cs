using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minio;
using TestEducation.API.Middleware;
using TestEducation.Aplication;
using TestEducation.Aplication.Common;
using TestEducation.Aplication.Helpers.JwtService;
using TestEducation.Aplication.Helpers.SeedData;
using TestEducation.Data;
using TestEducation.DataAcces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddJwtAuth(builder.Configuration);

builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddScoped<AppDbContext>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddApplication(builder.Configuration);

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
        policy.WithOrigins()
        .WithMethods("GET", "POST", "put", "delete")
        .WithHeaders("Content - type", "Authorization")
        .AllowCredentials();
    });
});

var app = builder.Build();


app.UseCors("StrictCorsPolicy");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RolePermissionSeeder>();
    context.SeedMapping();
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
