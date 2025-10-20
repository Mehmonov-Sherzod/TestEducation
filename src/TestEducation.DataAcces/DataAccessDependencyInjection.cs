using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestEducation.Aplication.Helpers.SeedData;
using TestEducation.Data;

namespace TestEducation.DataAcces
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDatabase(configuration);
            services.AddRepositories();

            return services;
        }
        private static void AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<RolePermissionSeeder>();
        }
        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
}
}
