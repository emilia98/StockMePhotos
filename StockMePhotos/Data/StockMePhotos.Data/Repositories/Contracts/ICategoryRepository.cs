using StockMePhotos.Data.Models;
using System.Linq.Expressions;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync<TKey>(Expression<Func<Category, TKey>> orderBy);
    }
}
