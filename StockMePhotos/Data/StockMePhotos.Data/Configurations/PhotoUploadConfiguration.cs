using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;
using System.Text;

namespace StockMePhotos.Data.Configurations
{
    public class PhotoUploadConfiguration : IEntityTypeConfiguration<PhotoUpload>
    {
        private readonly IEnumerable<PhotoUpload> PhotosUploads = new List<PhotoUpload>
        {
            new PhotoUpload
            {
                Id = 1,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264895/lion-in-the-wild_y6rzx0.webp",
                PhotoId = Guid.Parse("3c2161d2-92c0-4511-b390-7b3a862d72ea")
            },
            new PhotoUpload
            {
                Id = 2,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264382/running-horse_nk2imj.jpg",
                PhotoId = Guid.Parse("398ac8ba-b365-495e-95ca-8d2d17c5065c")
            },
            new PhotoUpload
            {
                Id = 3,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264388/mountain-river_qk7yll.avif",
                PhotoId = Guid.Parse("3606010e-60d1-467e-b85f-1c93bd1a2c22")
            },
            new PhotoUpload
            {
                Id = 4,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264699/modern-glass-skyscraper_f11xyq.jpg",
                PhotoId = Guid.Parse("0c71e3e7-b60a-4633-a906-0e996724f4fe")
            },
            new PhotoUpload
            {
                Id = 5,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265103/historic-stone-bridge_sncska.jpg",
                PhotoId = Guid.Parse("c6031c0d-d5f9-4434-b0ec-b40481613481")
            },
            new PhotoUpload
            {
                Id = 6,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265186/eagle-in-flight_qykv4v.jpg",
                PhotoId = Guid.Parse("97e1fee6-c879-4b66-a1c2-3804d736cdf4")
            },
            new PhotoUpload
            {
                Id = 7,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265564/football-stadium-crowd_zvvkso.jpg",
                PhotoId = Guid.Parse("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045")
            },
            new PhotoUpload
            {
                Id = 8,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265493/traditional-wooden-pagoda_zq5enw.jpg",
                PhotoId = Guid.Parse("b192d3de-8452-4b11-9e2f-fa66a2216585")
            },
            new PhotoUpload
            {
                Id = 9,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265794/ancient-temple-ruins_xszn2q.jpg",
                PhotoId = Guid.Parse("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8")
            },
            new PhotoUpload
            {
                Id = 10,
                ImageURL = "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265795/snowy-mountain-peak_njsdu5.jpg",
                PhotoId = Guid.Parse("cef5077c-120a-4940-9db5-12781982d2f3")
            }
        };


        public void Configure(EntityTypeBuilder<PhotoUpload> entity)
        {
            entity
                .HasData(PhotosUploads);

            entity
                .HasIndex(pu => pu.PhotoId)
                .IsUnique();
        }
    }
}
