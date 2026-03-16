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

        public async Task AddCategoryToPhotoAsync(Guid photoId, int categoryId)
        {
            bool photoCategoryExists = await this.dbContext
                .PhotosCategories
                .AnyAsync(pc => pc.PhotoId == photoId && pc.CategoryId == categoryId);

            if (photoCategoryExists) return;

            PhotoCategory newPhotoCategory = new PhotoCategory()
            {
                PhotoId = photoId,
                CategoryId = categoryId
            };

            await this.dbContext.PhotosCategories.AddAsync(newPhotoCategory);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
