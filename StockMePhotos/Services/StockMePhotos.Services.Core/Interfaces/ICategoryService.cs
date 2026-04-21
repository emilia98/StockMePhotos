using StockMePhotos.Data.Repositories;
using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> ListAllCategories();

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOrderedById();

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOrderedByName();

        public Task<bool> CategoryWithSlugExistsAsync(string slug);

        public Task<bool> CategoryWithIdExistsAsync(int id);

        public Task<bool> CreateCategoryAsync(CategoryFormModel formModel, string slug);

        public Task<UpdateCategoryFormModel?> GetCategoryToUpdateByIdAsync(int categoryId);

        public Task<bool> UpdateCategoryAsync(int categoryId, string slug, string description);

        Task<bool> RemoveCategoryAsync(int categoryId);
    }
}
