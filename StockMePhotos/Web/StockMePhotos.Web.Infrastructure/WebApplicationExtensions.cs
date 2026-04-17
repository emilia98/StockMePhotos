using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StockMePhotos.Data.Seeding.Contracts;

namespace StockMePhotos.Web.Infrastructure
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseRolesSeeder(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope scope = applicationBuilder
                .ApplicationServices
                .CreateScope();

            IRolesSeeder rolesSeeder = scope
                .ServiceProvider
                .GetRequiredService<IRolesSeeder>();

            rolesSeeder
                .SeedRolesAsync()
                .GetAwaiter()
                .GetResult();

            return applicationBuilder;
        }
    }
}
