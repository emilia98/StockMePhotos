using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;

namespace StockMePhotos.Data.Repositories
{
    public class FavoritePhotoRepository : BaseRepository, IFavoritePhotoRepository
    {
        public FavoritePhotoRepository(StockMePhotosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddPhotoToFavoritesAsync(FavoritePhoto favoritePhoto)
        {
            await DbContext!.FavoritePhotos.AddAsync(favoritePhoto);
            int resultCount = await DbContext!.SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<bool> DoesPhotoExistInFavoriteAsync(string photoId, string userId)
        {
            return await DbContext!
                .FavoritePhotos
                .AnyAsync(fp => fp.Id.ToString().ToLower() == photoId.ToLower()
                                && fp.UserId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<IEnumerable<FavoritePhoto>> GetFavoritePhotoByUserAsync(string userId)
        {
            return await DbContext!
                .FavoritePhotos
                .AsNoTracking()
                .Include(fp => fp.Photo)
                .ThenInclude(fp => fp.PhotoUpload)
                .Where(fp => fp.UserId.ToString().ToLower() == userId.ToLower())
                .OrderByDescending(fp => fp.Photo.DateAdded)
                .ToListAsync();
        }

        public async Task<FavoritePhoto?> GetFavoritePhotoToRemoveAsync(string photoId, string userId)
        {
            return await DbContext!
                .FavoritePhotos
                .SingleOrDefaultAsync(fp => fp.PhotoId.ToString().ToLower() == photoId.ToLower()
                                            && fp.UserId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> RemovePhotoFromFavoritesAsync(FavoritePhoto favoritePhoto)
        {
            DbContext!.FavoritePhotos.Remove(favoritePhoto);
            int resultCount = await DbContext!.SaveChangesAsync();

            return resultCount == 1;
        }
    }
}
