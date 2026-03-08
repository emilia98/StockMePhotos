using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
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
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        public virtual DbSet<Category> Categories { get; set; } = null!;

        public virtual DbSet<Photo> Photos { get; set; } = null!;

        public virtual DbSet<PhotoUpload> PhotoUploads { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
