using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class PhotoCategoryConfiguration : IEntityTypeConfiguration<PhotoCategory>
    {
        private readonly IEnumerable<PhotoCategory> PhotosCategories = new List<PhotoCategory>
        {
            new PhotoCategory
            {
                Id = 1,
                PhotoId = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
                CategoryId = 8
            },
            new PhotoCategory
            {
                Id = 2,
                PhotoId = Guid.Parse("398ac8ba-b365-495e-95ca-8d2d17c5065c"),
                CategoryId = 8
            },
            new PhotoCategory
            {
                Id = 3,
                PhotoId = Guid.Parse("3606010e-60d1-467e-b85f-1c93bd1a2c22"),
                CategoryId = 1
            },
            new PhotoCategory
            {
                Id = 4,
                PhotoId = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
                CategoryId = 9
            },
            new PhotoCategory
            {
                Id = 5,
                PhotoId = Guid.Parse("c6031c0d-d5f9-4434-b0ec-b40481613481"),
                CategoryId = 5
            },
            new PhotoCategory
            {
                Id = 6,
                PhotoId = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
                CategoryId = 8
            },
            new PhotoCategory
            {
                Id = 7,
                PhotoId = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
                CategoryId = 7
            },
            new PhotoCategory
            {
                Id = 8,
                PhotoId = Guid.Parse("b192d3de-8452-4b11-9e2f-fa66a2216585"),
                CategoryId = 5
            },
            new PhotoCategory
            {
                Id = 9,
                PhotoId = Guid.Parse("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"),
                CategoryId = 5
            },
            new PhotoCategory
            {
                Id = 10,
                PhotoId = Guid.Parse("cef5077c-120a-4940-9db5-12781982d2f3"),
                CategoryId = 1
            },
        };


        public void Configure(EntityTypeBuilder<PhotoCategory> entity)
        {
            entity
                .HasIndex(pc => new { pc.PhotoId, pc.CategoryId })
                .IsUnique();

            entity
                .HasData(PhotosCategories);
        }
    }
}