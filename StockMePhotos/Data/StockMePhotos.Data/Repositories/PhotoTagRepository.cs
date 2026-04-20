using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;

namespace StockMePhotos.Data.Repositories
{
    public class PhotoTagRepository : BaseRepository, IPhotoTagRepository
    {
        public PhotoTagRepository(StockMePhotosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PhotoTag?> GetPhotoTagByIds(string photoId, int tagId)
        {
            return await DbContext!
                .PhotosTags
                .FirstOrDefaultAsync(pt => pt.PhotoId.ToString().ToLower() == photoId.ToLower() && pt.TagId == tagId);
        }

        public async Task<bool> AddTagToPhotoAsync(PhotoTag photoTag)
        {
            await DbContext!.PhotosTags.AddAsync(photoTag);
            int resultCount = await SaveChangesAsync();
            return resultCount == 1;
        }

        public async Task<bool> TagAssignedToPhotoAsync(int tagId, string photoId)
        {
            return await DbContext!
                .PhotosTags
                .AnyAsync(pt => pt.PhotoId.ToString().ToLower() == photoId.ToLower() && pt.TagId == tagId);
        }

        public async Task<IEnumerable<PhotoTag>> GetAllTagsAssignedToPhoto(string photoId)
        {
            return await DbContext!
                .PhotosTags
                .Where(pt => pt.PhotoId.ToString().ToLower() == photoId.ToLower())
                .ToListAsync();
        }

        public async Task<bool> RemoveTagFromPhotoAsync(PhotoTag photoTagToRemove)
        {
            DbContext!.Remove(photoTagToRemove);
            int resultCount = await SaveChangesAsync();
            return resultCount > 0;
        }
    }
}
