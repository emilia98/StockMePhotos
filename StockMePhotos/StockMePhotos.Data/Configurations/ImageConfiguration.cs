using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;
using static StockMePhotos.Data.Common.EntityConstants.Image;

namespace StockMePhotos.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> entity)
        {
            entity
                .HasKey(i => i.Id);

            entity
                .Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity
                .Property(i => i.Extension)
                .IsRequired()
                .HasMaxLength(ExtensionMaxLength);

            entity
                .Property(i => i.AltText)
                .IsRequired()
                .HasMaxLength(AltTextMaxLength);

            entity
                .Property(i => i.URL)
                .IsRequired()
                .HasMaxLength(URLMaxLength);
        }
    }
}
