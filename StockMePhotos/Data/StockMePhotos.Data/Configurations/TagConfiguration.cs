using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        private readonly IEnumerable<Tag> Tags = new List<Tag>
        {
            new Tag
            {
                Id = 1,
                Name = "Sunset",
                Slug = "sunset"
            },
            new Tag
            {
                Id = 2,
                Name = "Portrait",
                Slug = "portrait"
            },
            new Tag
            {
                Id = 3,
                Name = "Minimal",
                Slug = "minimal"
            },
            new Tag
            {
                Id = 4,
                Name = "Vintage",
                Slug = "vintage"
            },
            new Tag
            {
                Id = 5,
                Name = "Street",
                Slug = "street"
            },
            new Tag
            {
                Id = 6,
                Name = "Aerial",
                Slug = "aerial"
            },
            new Tag
            {
                Id = 7,
                Name = "Black & White",
                Slug = "black-white"
            },
            new Tag
            {
                Id = 8,
                Name = "Night",
                Slug = "night"
            },
            new Tag
            {
                Id = 9,
                Name = "Macro",
                Slug = "macro"
            },
            new Tag
            {
                Id = 10,
                Name = "Urban",
                Slug = "urban"
            },
        };

        public void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity
                .Property(t => t.DateAdded)
                .HasDefaultValueSql("GETUTCDATE()");
            
            entity
                .HasData(Tags);
        }
    }
}
