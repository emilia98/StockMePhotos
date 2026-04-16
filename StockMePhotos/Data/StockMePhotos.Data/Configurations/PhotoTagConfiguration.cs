using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class PhotoTagConfiguration : IEntityTypeConfiguration<PhotoTag>
    {
        public void Configure(EntityTypeBuilder<PhotoTag> entity)
        {
            entity
                .HasIndex(pt => new { pt.PhotoId, pt.TagId })
                .IsUnique();
        }
    }
}