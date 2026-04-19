using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;

namespace StockMePhotos.Data.Repositories
{
    public class PhotoUploadRepository : BaseRepository, IPhotoUploadRepository
    {
        public PhotoUploadRepository(StockMePhotosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddPhotoUploadAsync(PhotoUpload photoUpload)
        {
            await DbContext!.PhotoUploads.AddAsync(photoUpload);
            int resultCount = await DbContext!.SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<bool> DeletePhotoUploadAsync(PhotoUpload photoUpload)
        {
            DbContext!.PhotoUploads.Remove(photoUpload);
            int resultCount = await DbContext!.SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<PhotoUpload?> GetPhotoUploadByPhotoAsync(string photoId)
        {
            return await DbContext!.PhotoUploads
                .FirstOrDefaultAsync(pu => pu.PhotoId.ToString().ToLower() == photoId.ToLower());
        }
    }
}
