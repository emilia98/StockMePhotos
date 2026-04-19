using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface IPhotoCategoryRepository
    {
        public Task<bool> CategoryAssignedToPhotoAsync(int categoryId, string photoId);

        public Task<bool> AddCategoryToPhotoAsync(PhotoCategory photoCategory);

        public Task<bool> RemoveCategoryFromPhotoAsync(IEnumerable<PhotoCategory> photoCategoriesToRemove);

        public Task<IEnumerable<PhotoCategory>> GetAllCategoriesAssignedToPhoto(string photoId);
    }
}
