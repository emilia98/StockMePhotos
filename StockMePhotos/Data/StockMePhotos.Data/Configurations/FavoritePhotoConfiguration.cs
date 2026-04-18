using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class FavoritePhotoConfiguration : IEntityTypeConfiguration<FavoritePhoto>
    {
        private readonly IEnumerable<FavoritePhoto> FavoritePhotos = new List<FavoritePhoto>()
        {
            new FavoritePhoto()
            {
                Id = 1,
                PhotoId = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
                UserId = Guid.Parse("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323")
            },
            new FavoritePhoto()
            {
                Id = 2,
                PhotoId = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
                UserId = Guid.Parse("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323")
            },
            new FavoritePhoto()
            {
                Id = 3,
                PhotoId = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
                UserId = Guid.Parse("97dfe4b4-8f5b-4a44-971d-6f62037bcde5")
            },
            new FavoritePhoto()
            {
                Id = 4,
                PhotoId = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
                UserId = Guid.Parse("0bb23ace-c418-4314-b8bb-09b3aeb9ab07")
            },
            new FavoritePhoto()
            {
                Id = 5,
                PhotoId = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
                UserId = Guid.Parse("0bb23ace-c418-4314-b8bb-09b3aeb9ab07")
            },
            new FavoritePhoto()
            {
                Id = 6,
                PhotoId = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
                UserId = Guid.Parse("0bb23ace-c418-4314-b8bb-09b3aeb9ab07")
            },
            new FavoritePhoto()
            {
                Id = 7,
                PhotoId = Guid.Parse("b192d3de-8452-4b11-9e2f-fa66a2216585"),
                UserId = Guid.Parse("97dfe4b4-8f5b-4a44-971d-6f62037bcde5")
            },
            new FavoritePhoto()
            {
                Id = 8,
                PhotoId = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
                UserId = Guid.Parse("97dfe4b4-8f5b-4a44-971d-6f62037bcde5")
            },
        };

        public void Configure(EntityTypeBuilder<FavoritePhoto> entity)
        {
            entity
                .HasOne(fp => fp.Photo)
                .WithMany(p => p.ToFavorites)
                .HasForeignKey(fp => fp.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);


            entity
                .HasOne(fp => fp.User)
                .WithMany(u => u.FavoritePhotos)
                .HasForeignKey(fp => fp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasIndex(fp => new { fp.PhotoId, fp.UserId })
                .IsUnique();

            entity
                .HasData(FavoritePhotos);
        }
    }
}
