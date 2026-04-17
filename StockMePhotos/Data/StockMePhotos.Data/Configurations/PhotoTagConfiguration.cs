using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class PhotoTagConfiguration : IEntityTypeConfiguration<PhotoTag>
    {
        private readonly ICollection<PhotoTag> PhotosTags = new List<PhotoTag>
        {
            // Image 1
            new PhotoTag
            {
                Id = 1,
                TagId = 11,
                PhotoId = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
            },
            new PhotoTag
            {
                Id = 2,
                TagId = 12,
                PhotoId = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
            },
            // Image 2
            new PhotoTag
            {
                Id = 3,
                TagId = 11,
                PhotoId = Guid.Parse("398ac8ba-b365-495e-95ca-8d2d17c5065c"),
            },
            new PhotoTag
            {
                Id = 4,
                TagId = 12,
                PhotoId = Guid.Parse("398ac8ba-b365-495e-95ca-8d2d17c5065c"),
            },
            // Image 3
            new PhotoTag
            {
                Id = 5,
                TagId = 12,
                PhotoId = Guid.Parse("3606010e-60d1-467e-b85f-1c93bd1a2c22")
            },
            new PhotoTag
            {
                Id = 6,
                TagId = 15,
                PhotoId = Guid.Parse("3606010e-60d1-467e-b85f-1c93bd1a2c22")
            },
            // Image 4
            new PhotoTag
            {
                Id = 7,
                TagId = 5,
                PhotoId = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
            },
            new PhotoTag
            {
                Id = 8,
                TagId = 10,
                PhotoId = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
            },
            new PhotoTag
            {
                Id = 9,
                TagId = 15,
                PhotoId = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
            },
            // Image 5
            new PhotoTag
            {
                Id = 10,
                TagId = 13,
                PhotoId =  Guid.Parse("c6031c0d-d5f9-4434-b0ec-b40481613481"),
            },
            // Image 6
            new PhotoTag
            {
                Id = 11,
                TagId = 11,
                PhotoId = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
            },
            new PhotoTag
            {
                Id = 12,
                TagId = 12,
                PhotoId = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
            },
            // Image 7
            new PhotoTag
            {
                Id = 13,
                TagId = 10,
                PhotoId = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
            },
            new PhotoTag
            {
                Id = 14,
                TagId = 14,
                PhotoId = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
            },
            // Image 8
            new PhotoTag
            {
                Id = 15,
                TagId = 4,
                PhotoId = Guid.Parse("b192d3de-8452-4b11-9e2f-fa66a2216585"),
            },
            new PhotoTag
            {
                Id = 16,
                TagId = 13,
                PhotoId = Guid.Parse("b192d3de-8452-4b11-9e2f-fa66a2216585"),
            },
            // Image 9
            new PhotoTag
            {
                Id = 17,
                TagId = 4,
                PhotoId = Guid.Parse("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"),
            },
            new PhotoTag
            {
                Id = 18,
                TagId = 13,
                PhotoId = Guid.Parse("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"),
            },
            // Image 10
            new PhotoTag
            {
                Id = 19,
                TagId = 12,
                PhotoId = Guid.Parse("cef5077c-120a-4940-9db5-12781982d2f3"),
            },
            new PhotoTag
            {
                Id = 20,
                TagId = 15,
                PhotoId = Guid.Parse("cef5077c-120a-4940-9db5-12781982d2f3"),
            }
        };

        public void Configure(EntityTypeBuilder<PhotoTag> entity)
        {
            entity
                .HasIndex(pt => new { pt.PhotoId, pt.TagId })
                .IsUnique();

            entity
                .HasData(PhotosTags);
        }
    }
}