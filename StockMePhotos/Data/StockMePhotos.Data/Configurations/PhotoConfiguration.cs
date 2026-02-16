using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        private readonly ICollection<Photo> Photos = new List<Photo>
        {
            new Photo
            {
                Id = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
                Title = "Lion in the Wild",
                Slug = "lion-in-the-wild",
                Description = "Majestic lion resting in golden savannah grass.",
                UserId = "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"
            },
            new Photo
            {
                Id = Guid.Parse("398ac8ba-b365-495e-95ca-8d2d17c5065c"),
                Title = "Running Horse",
                Slug = "running-horse",
                Description = "Wild horse running freely across open fields.",
                UserId = "97dfe4b4-8f5b-4a44-971d-6f62037bcde5"
            },
            new Photo
            {
                Id = Guid.Parse("3606010e-60d1-467e-b85f-1c93bd1a2c22"),
                Title = "Mountain River",
                Slug = "mountain-river",
                Description = "Clear river flowing between rocks and pine trees.",
                UserId = "97dfe4b4-8f5b-4a44-971d-6f62037bcde5"
            },
            new Photo
            {
                Id = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
                Title = "Modern Glass Skyscraper",
                Slug = "modern-glass-skyscraper",
                Description = "modern-glass-skyscraper",
                UserId = "97dfe4b4-8f5b-4a44-971d-6f62037bcde5"
            },
            new Photo
            {
                Id = Guid.Parse("c6031c0d-d5f9-4434-b0ec-b40481613481"),
                Title = "Historic Stone Bridge",
                Slug = "historic-stone-bridge",
                Description = "Old arched bridge crossing a calm river.",
                UserId = "0bb23ace-c418-4314-b8bb-09b3aeb9ab07"
            },
            new Photo
            {
                Id = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
                Title = "Eagle in Flight",
                Slug = "eagle-in-flight",
                Description = "Powerful eagle soaring high above the mountains.",
                UserId = "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"
            },
            new Photo
            {
                Id = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
                Title = "Football Stadium Crowd",
                Slug = "football-stadium-crowd",
                Description = "Fans cheering inside a packed football stadium.",
                UserId = "97dfe4b4-8f5b-4a44-971d-6f62037bcde5"
            },
            new Photo
            {
                Id = Guid.Parse("b192d3de-8452-4b11-9e2f-fa66a2216585"),
                Title = "Traditional Wooden Pagoda",
                Slug = "traditional-wooden-pagoda",
                Description = "Multi-level pagoda surrounded by autumn trees.",
                UserId = "0bb23ace-c418-4314-b8bb-09b3aeb9ab07"
            },
            new Photo
            {
                Id = Guid.Parse("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"),
                Title = "Ancient Temple Ruins",
                Slug = "ancient-temple-ruins",
                Description = "Stone temple remains surrounded by jungle.",
                UserId = "0bb23ace-c418-4314-b8bb-09b3aeb9ab07"
            },
            new Photo
            {
                Id = Guid.Parse("cef5077c-120a-4940-9db5-12781982d2f3"),
                Title = "Snowy Mountain Peak",
                Slug = "snowy-mountain-peak",
                Description = "Sharp snowy mountain under a clear sky.",
                UserId = "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"
            },
        };


        public void Configure(EntityTypeBuilder<Photo> entity)
        {
            entity
                .Property(p => p.DateAdded)
                .HasDefaultValueSql("GETUTCDATE()");

            entity
                .Property(p => p.LastModified)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

            entity
               .HasData(Photos);

            /*
            entity
                .HasOne(p => p.PhotoUpload)
                .WithOne(pu => pu.Photo)
                .HasForeignKey<PhotoUpload>(pu => pu.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);
            */
        }
    }
}