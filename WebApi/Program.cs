
using Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using ProductService.Seeding;
using WebApi.Extensions;
using WebApi.MiddleWares;

namespace WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerDocumentation();
            builder.Services.AddApplicationDbContext(builder.Configuration, builder.Environment);
            builder.Services.AddApplicationService(builder.Configuration);



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseSwaggerDocumentation();
            app.UseCors();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #region Insure Creation Of Database before Application Run at Production Environment
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            if (app.Environment.IsProduction() && (await context.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                try
                {
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Database Migrated Successfully");
                    await ApplicationDbContextSeeding.Seed(context);
                    logger.LogInformation("Database Seeded Successfully");

                }
                catch (Exception e)
                {
                    logger.LogError(e, "An Error Occurred While Migrating Database");
                }
            }
            #endregion




            app.Run();
        }
    }
}
