using StockMePhotos.Data.Models;
using System.Linq.Expressions;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync<TKey>(Expression<Func<Category, TKey>> orderBy);

        public Task<bool> AddCategoryAsync(Category category);

        public Task<bool> DeleteCategoryAsync(Category category);

        public IQueryable<Category> GetAllCategoriesNoTracking();

        public Task<Category?> GetCategoryByIdAsync(int id);

        public Task<bool> CategoryWithSlugExists(string slug);

        public Task<bool> CategoryWithIdExists(int id);

        public Task<Category?> CategoryWithSlug(string slug);

        public Task<bool> UpdateCategoryAsync(Category updatedCategory);
    }
}
