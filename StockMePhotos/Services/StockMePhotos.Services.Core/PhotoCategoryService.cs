using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Services.Core.Interfaces;

namespace StockMePhotos.Services.Core
{
    public class PhotoCategoryService : IPhotoCategoryService
    {
        private readonly StockMePhotosDbContext dbContext;

        public PhotoCategoryService(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCategoryToPhotoAsync(string photoId, int categoryId)
        {
            bool photoCategoryExists = await this.dbContext
                .PhotosCategories
                .AnyAsync(pc => pc.PhotoId.ToString().ToLower() == photoId.ToLower() && pc.CategoryId == categoryId);

            if (photoCategoryExists) return;

            PhotoCategory newPhotoCategory = new PhotoCategory()
            {
                PhotoId = Guid.Parse(photoId),
                CategoryId = categoryId
            };

            await this.dbContext.PhotosCategories.AddAsync(newPhotoCategory);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveCategoryFromPhotoAsync(string photoId)
        {
            IEnumerable<PhotoCategory> photoCategoriesToRemove = await this.dbContext
                .PhotosCategories
                .Where(pc => pc.PhotoId.ToString().ToLower() == photoId.ToLower())
                .ToListAsync();

            this.dbContext.RemoveRange(photoCategoriesToRemove);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
