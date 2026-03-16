using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IFavoritePhotoService
    {
        Task AddPhotoToFavorites(string photoId, string userId);

        Task RemovePhotoFromFavorites(string photoId, string userId);

        Task<IEnumerable<PhotoViewModel>> GetAllFavoritePhotosByUserAsync(string userId);
    }
}
