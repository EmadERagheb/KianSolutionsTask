
using Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class ApplicationDbContextServiceExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    options => options.CommandTimeout(30).EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null));
                options.LogTo(Console.WriteLine, LogLevel.Information);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                if (env.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }

            });

            return services;
        }
    }
}
