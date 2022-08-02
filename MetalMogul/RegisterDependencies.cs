using MetalMogul.Data;
using MetalMogul.Repositories.ConcertRepository;
using MetalMogul.Services.ConcertService;
using Microsoft.EntityFrameworkCore;

namespace MetalMogul
{
    public static class RegisterDependencies
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:MetalMogul"];

            services.AddDbContext<MetalDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IConcertRepository, ConcertRepository>();
            services.AddScoped<IConcertService, ConcertService>();
        }
    }
}
