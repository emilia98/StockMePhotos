using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using System.Linq.Expressions;

namespace StockMePhotos.Data.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(StockMePhotosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync<TKey>(Expression<Func<Category, TKey>> orderBy)
        {
            return await DbContext!
                .Categories
                .AsNoTracking()
                .OrderBy(orderBy)
                .Include(c => c.PhotoCategories)
                .ToListAsync();
        }
    }
}
