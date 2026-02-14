using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace StockMePhotos.Data
{
    public class StockMePhotosDbContext : DbContext
    {
        public StockMePhotosDbContext(DbContextOptions<StockMePhotosDbContext> options)
            : base(options)
        {
        }

        // DbSets go here


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
