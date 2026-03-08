using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class PhotoUploadConfiguration : IEntityTypeConfiguration<PhotoUpload>
    {
        public void Configure(EntityTypeBuilder<PhotoUpload> entity)
        {
            entity
                .HasIndex(pu => pu.PhotoId)
                .IsUnique();
        }
    }
}
