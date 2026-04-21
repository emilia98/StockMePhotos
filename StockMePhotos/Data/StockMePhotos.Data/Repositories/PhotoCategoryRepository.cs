using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;

namespace StockMePhotos.Data.Repositories
{
    public class PhotoCategoryRepository : BaseRepository, IPhotoCategoryRepository
    {
        public PhotoCategoryRepository(StockMePhotosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddCategoryToPhotoAsync(PhotoCategory photoCategory)
        {
            await DbContext!.PhotosCategories.AddAsync(photoCategory);
            int resultCount = await DbContext!.SaveChangesAsync();

            return resultCount == 1;
        }

        public async Task<bool> CategoryAssignedToPhotoAsync(int categoryId, string photoId)
        {
            return await DbContext!
                .PhotosCategories
                .AnyAsync(pc => pc.PhotoId.ToString().ToLower() == photoId.ToLower() && pc.CategoryId == categoryId);
        }

        public async Task<IEnumerable<PhotoCategory>> GetAllCategoriesAssignedToPhoto(string photoId)
        {
            return await DbContext!
                .PhotosCategories
                .Where(pc => pc.PhotoId.ToString().ToLower() == photoId.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<PhotoCategory>> GetAllPhotosWithAssignedCategory(int categoryId)
        {
            return await DbContext!
                .PhotosCategories
                .Where(pc => pc.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<bool> RemoveCategoryFromPhotoAsync(IEnumerable<PhotoCategory> photoCategoriesToRemove)
        {
            DbContext!.RemoveRange(photoCategoriesToRemove);
            int resultCount = await SaveChangesAsync();
            return resultCount > 0;
        }
    }
}
