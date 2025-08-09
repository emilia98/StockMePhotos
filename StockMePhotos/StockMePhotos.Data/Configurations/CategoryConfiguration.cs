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

            entity
                .HasData(SeedCategories());
        }

        private IEnumerable<Category> SeedCategories()
        {
            List<Category> categoriesToSeed = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Nature",
                    Description = "Showcases the beauty of the natural world, from lush forests and flowing rivers to flowers and seasonal scenery.",
                    Slug = "nature"
                },
                new Category
                {
                    Id = 2,
                    Name = "Portrait",
                    Description = "Highlights individuals or groups with a focus on facial expressions, emotions, and personality.\r\n\r\n",
                    Slug = "portrait"
                },
                new Category
                {
                    Id = 3,
                    Name = "Landscape",
                    Description = "Captures wide and scenic views of mountains, valleys, oceans, and other breathtaking outdoor vistas.",
                    Slug = "landscape"
                },
                new Category
                {
                    Id = 4,
                    Name = "Animals",
                    Description = "Features wildlife and pets in their natural habitats or playful moments, emphasizing their charm and character.",
                    Slug = "animals"
                },
                new Category
                {
                    Id = 5,
                    Name = "People",
                    Description = "Depicts everyday life, candid moments, and human interactions across cultures and settings.",
                    Slug = "people"
                }
            };

            return categoriesToSeed;
        }
    }
}
