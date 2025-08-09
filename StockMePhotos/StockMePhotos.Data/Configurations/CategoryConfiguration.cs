using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;
using static StockMePhotos.Data.Common.EntityConstants.Category;

namespace StockMePhotos.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            // Define the primary key of the Category entity
            entity
                .HasKey(c => c.Id);

            // Define the constraints for the Name column
            entity
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            // Define the constraints for the Description column
            entity
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            // Define the constraints for the Slug column
            entity
                .Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(SlugMaxLength);

            // Define the constraints for the IsDeleted column
            entity
                .Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
