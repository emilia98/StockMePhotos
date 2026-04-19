using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core
{
    public class FavoritePhotoService : IFavoritePhotoService
    {
        private readonly IFavoritePhotoRepository favoritePhotoRepository;

        public FavoritePhotoService(IFavoritePhotoRepository favoritePhotoRepository)
        {
            this.favoritePhotoRepository = favoritePhotoRepository;
        }

        public async Task AddPhotoToFavorites(string photoId, string userId)
        {
            bool doesPhotoExistInFavorites = await favoritePhotoRepository.DoesPhotoExistInFavoriteAsync(photoId, userId);

            if (!doesPhotoExistInFavorites)
            {
                FavoritePhoto newFavoritePhoto = new FavoritePhoto
                {
                    PhotoId = Guid.Parse(photoId),
                    UserId = Guid.Parse(userId)
                };

                await favoritePhotoRepository.AddPhotoToFavoritesAsync(newFavoritePhoto);
            }
        }

        public async Task RemovePhotoFromFavorites(string photoId, string userId)
        {
            FavoritePhoto? favoritePhotoToRemove = await favoritePhotoRepository.GetFavoritePhotoToRemoveAsync(photoId, userId);

            if (favoritePhotoToRemove != null)
            {
                await favoritePhotoRepository.RemovePhotoFromFavoritesAsync(favoritePhotoToRemove);
            }
        }

        public async Task<IEnumerable<PhotoViewModel>> GetAllFavoritePhotosByUserAsync(string userId)
        {
            IEnumerable<FavoritePhoto> favoritePhotosByUserFromDb = await favoritePhotoRepository
                .GetFavoritePhotoByUserAsync(userId);

            return favoritePhotosByUserFromDb.Select(fp => new PhotoViewModel
            {
                Id = fp.Photo.Id.ToString(),
                Title = fp.Photo.Title,
                ImageURL = fp.Photo.PhotoUpload?.ImageURL,
                DateAdded = fp.Photo.DateAdded.ToString("dd/MM/yyyy"),
                Categories = fp.Photo.PhotoCategories.Select(c => c.Category.Name)
            });
        }

    }
}
