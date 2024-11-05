
using Data.Contracts;
using Data.Repositories;
using System.Text;
namespace WebApi.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            #region CORS Policy
            services.AddCors(setupAction =>
              setupAction.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(config["ClientOrgins"]!.Split(","))));
            #endregion
            return services;
        }
    }
}
