using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;
using static StockMePhotos.Data.Common.EntityConstants.Tag;

namespace StockMePhotos.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> entity)
        {
            // Define the primary key of the Tag entity
            entity
                .HasKey(t => t.Id);

            // Define the constraints of the Name column
            entity
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            // Define the constraints of the Slug column
            entity
                .Property(t => t.Slug)
                .IsRequired()
                .HasMaxLength(SlugMaxLength);

            // Define the constraints of the IsDeleted column
            entity
                .Property(t => t.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasData(SeedTags());
        }

        public IEnumerable<Tag> SeedTags()
        {
            List<Tag> tagsToSeed = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "Cat",
                    Slug = "cat"
                },
                new Tag
                {
                    Id = 2,
                    Name = "Dog",
                    Slug = "dog"
                },
                new Tag
                {
                    Id = 3,
                    Name = "Flower",
                    Slug = "flower"
                },
                new Tag
                {
                    Id = 4,
                    Name = "Sea",
                    Slug = "sea"
                },
                new Tag
                {
                    Id = 5,
                    Name = "Mountain",
                    Slug = "mountain"
                }
            };

            return tagsToSeed;
        }
    }
}
