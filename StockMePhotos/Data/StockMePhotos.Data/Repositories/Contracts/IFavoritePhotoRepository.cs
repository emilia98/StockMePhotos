using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface IFavoritePhotoRepository
    {
        public Task<bool> DoesPhotoExistInFavoriteAsync(string photoId, string userId);

        public Task<bool> AddPhotoToFavoritesAsync(FavoritePhoto favoritePhoto);

        public Task<bool> RemovePhotoFromFavoritesAsync(FavoritePhoto favoritePhoto);

        public Task<FavoritePhoto?> GetFavoritePhotoToRemoveAsync(string photoId, string userId);

        public Task<IEnumerable<FavoritePhoto>> GetFavoritePhotoByUserAsync(string userId);
    }
}
