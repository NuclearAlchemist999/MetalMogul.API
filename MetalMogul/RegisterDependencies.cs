using MetalMogul.Data;
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
    }
}
