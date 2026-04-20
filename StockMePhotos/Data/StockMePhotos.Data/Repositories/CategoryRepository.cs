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

        public async Task<bool> AddCategoryAsync(Category category)
        {
            await DbContext!.Categories.AddAsync(category);
            int resultCount = await SaveChangesAsync();
            return resultCount == 1;
        }

        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            DbContext!.Categories.Remove(category);
            int resultCount = await SaveChangesAsync();
            return resultCount == 1;
        }

        public IQueryable<Category> GetAllCategoriesNoTracking()
        {
            return DbContext!
                .Categories
                .AsNoTracking();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await DbContext!
                .Categories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CategoryWithSlugExists(string slug)
        {
            return await DbContext!
                .Categories
                .AnyAsync(c => c.Slug == slug);
        }

        public async Task<bool> CategoryWithIdExists(int id)
        {
            return await DbContext!
                .Categories
                .AnyAsync(c => c.Id == id);
        }

        public async Task<Category?> CategoryWithSlug(string slug)
        {
            return await DbContext!
                .Categories
                .FirstOrDefaultAsync(c => c.Slug == slug);
        }
        
        public async Task<bool> UpdateCategoryAsync(Category updatedCategory)
        {
            DbContext!.Categories.Update(updatedCategory);
            int resultCount = await SaveChangesAsync();
            return resultCount == 1;
        }
    }
}
