using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> ListAllCategories();

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOrderedById();

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOrderedByName();
    }
}
