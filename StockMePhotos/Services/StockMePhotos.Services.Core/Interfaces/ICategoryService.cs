using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> ListAllCategories();
    }
}
