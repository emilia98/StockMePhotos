using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StockMePhotos.Data.Seeding.Contracts;

namespace StockMePhotos.Web.Infrastructure
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseIdentitySeeder(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope scope = applicationBuilder
                .ApplicationServices
                .CreateScope();

            IIdentitySeeder identitySeeder = scope.ServiceProvider
               .GetRequiredService<IIdentitySeeder>();

            identitySeeder
                .SeedAsync()
                .GetAwaiter()
                .GetResult();

            return applicationBuilder;
        }
    }
}
