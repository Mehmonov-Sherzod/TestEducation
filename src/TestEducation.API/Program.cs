using TestEducation.API;
using TestEducation.API.Middleware;
using TestEducation.Aplication;
using TestEducation.Aplication.Helpers.SeedData;
using TestEducation.Data;
using TestEducation.DataAcces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
//service.AddControllers()
//                .AddJsonOptions(options =>
//                {
//                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//                });

builder.Services.AddControllers();

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
