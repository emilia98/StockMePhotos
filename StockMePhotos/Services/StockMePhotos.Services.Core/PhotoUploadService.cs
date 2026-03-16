using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Services.Core.Interfaces;

namespace StockMePhotos.Services.Core
{
    public class PhotoUploadService : IPhotoUploadService
    {
        private readonly StockMePhotosDbContext dbContext;

        public PhotoUploadService(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPhotoUploadAsync(Guid photoId, string imageURL)
        {
            PhotoUpload newPhotoUpload = new PhotoUpload()
            {
                PhotoId = photoId,
                ImageURL = imageURL
            };

            await this.dbContext.PhotoUploads.AddAsync(newPhotoUpload);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemovePhotoUploadAsync(string photoId)
        {
            PhotoUpload? photoUpload = await this.dbContext.PhotoUploads
                .FirstOrDefaultAsync(pu => pu.PhotoId.ToString().ToLower() == photoId.ToLower());

            if (photoUpload != null)
            {
                this.dbContext.PhotoUploads.Remove(photoUpload);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
