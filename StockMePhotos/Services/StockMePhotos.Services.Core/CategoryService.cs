using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly StockMePhotosDbContext dbContext;

        public CategoryService(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> ListAllCategories()
        {
            IEnumerable<CategoryViewModel> allCategories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return allCategories;
        }
    }
}
