using FluentValidation;
using FluentValidation.AspNetCore;
using Telegram.Bot;
using TestEducation.API;
using TestEducation.API.Filter;
using TestEducation.API.Middleware;
using TestEducation.Aplication;
using TestEducation.Aplication.Common;
using TestEducation.Aplication.Helpers.GenerateJwt;
using TestEducation.Aplication.Helpers.SeedData;
using TestEducation.Aplication.Models.Question;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Aplication.Models.Users;
using TestEducation.Aplication.Service.Impl;
using TestEducation.Aplication.Validators.QuestionValidator;
using TestEducation.Aplication.Validators.SubjectValidator;
using TestEducation.Aplication.Validators.UserValidatoe;
using TestEducation.DataAcces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSingleton<ITelegramBotClient>(sp =>
{
    var token = builder.Configuration["TelegramBot:Token"];
    return new TelegramBotClient(token);
});

builder.Services.AddHostedService<TelegramServiceOtp>();


builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
    );

builder.Services.AddFluentValidationAutoValidation();

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOption"));
builder.Services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

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

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
