using DocumentManagerApi.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace UserManager.Extensions
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Verifica se o banco de dados existe
            if (context.Database.GetPendingMigrations().Any())
            {
                try
                {
                    Console.WriteLine("Trying to create and migrate database");
                    context.Database.Migrate();
                }
                catch (SqlException exception) when (exception.Number == 1801)
                {
                    Console.WriteLine("Database already exists.");
                }

                context.SaveChanges();
            }
        }
    }
}
