using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly StockMePhotosDbContext dbContext;

        public PhotoService(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PhotoViewModel>> GetAll()
        {
            return await this.dbContext.Photos
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Include(p => p.PhotoUpload)
                .Include(p => p.PhotoCategories)
                .OrderBy(p => p.DateAdded)
                .Select(p => new PhotoViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageURL = p.PhotoUpload.ImageURL,
                    Categories = p.PhotoCategories.Select(c => c.Category.Name)
                })
                .ToListAsync();
        }

        public async Task<PhotoViewModel?> GetById(string id)
        {
            Photo? photoEntity = await this.GetPhotoEntityById(id);

            if (photoEntity != null)
            {
                return new PhotoViewModel
                {
                    Id = photoEntity.Id.ToString(),
                    ImageURL = photoEntity.PhotoUpload?.ImageURL,
                    Title = photoEntity.Title,
                    Categories = photoEntity.PhotoCategories.Select(c => c.Category.Name)
                };
            }

            return null;
        }

        private async Task<Photo?> GetPhotoEntityById(string id)
        {
            Photo? photoEntity = await this.dbContext.Photos
                .AsNoTracking()
                .Include(p => p.PhotoUpload)
                .Include(p => p.PhotoCategories)
                .FirstOrDefaultAsync(p => p.Id.ToString() == id);

            return photoEntity;
        }
    }
}
