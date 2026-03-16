using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core
{
    public class FavoritePhotoService : IFavoritePhotoService
    {
        private readonly StockMePhotosDbContext dbContext;

        public FavoritePhotoService(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPhotoToFavorites(string photoId, string userId)
        {
            bool doesPhotoExistInFavorites = await this.dbContext
                .FavoritePhotos
                .AnyAsync(fp => fp.Id.ToString().ToLower() == photoId.ToLower()
                                && fp.UserId.ToLower() == userId.ToLower());

            if (!doesPhotoExistInFavorites)
            {
                FavoritePhoto newFavoritePhoto = new FavoritePhoto
                {
                    PhotoId = Guid.Parse(photoId),
                    UserId = userId
                };

                await this.dbContext.FavoritePhotos.AddAsync(newFavoritePhoto);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task RemovePhotoFromFavorites(string photoId, string userId)
        {
            FavoritePhoto? favoritePhotoToRemove = await this.dbContext
                .FavoritePhotos
                .SingleOrDefaultAsync(fp => fp.PhotoId.ToString().ToLower() == photoId.ToLower()
                                            && fp.UserId.ToLower() == userId.ToLower());

            if (favoritePhotoToRemove != null)
            {
                this.dbContext.FavoritePhotos.Remove(favoritePhotoToRemove);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PhotoViewModel>> GetAllFavoritePhotosByUserAsync(string userId)
        {
            IEnumerable<PhotoViewModel> favoritePhotosByUser = await this.dbContext
                .FavoritePhotos
                .AsNoTracking()
                .Include(fp => fp.Photo)
                .Where(fp => fp.UserId.ToLower() == userId.ToLower())
                .OrderByDescending(fp => fp.Photo.DateAdded)
                .Select(fp => new PhotoViewModel
                {
                    Id = fp.Photo.Id.ToString(),
                    Title = fp.Photo.Title,
                    ImageURL = fp.Photo.PhotoUpload.ImageURL,
                    DateAdded = fp.Photo.DateAdded.ToString("dd/MM/yyyy"),
                    Categories = fp.Photo.PhotoCategories.Select(c => c.Category.Name)
                })
                .ToListAsync();

            return favoritePhotosByUser;
        }

    }
}
