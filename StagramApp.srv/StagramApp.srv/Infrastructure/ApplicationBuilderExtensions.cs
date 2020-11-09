using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StagramApp.srv.Data;

namespace StagramApp.srv.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

           var dbContext = services.ServiceProvider.GetService<StagramDbContext>();

            dbContext.Database.Migrate();
        }
    }
}