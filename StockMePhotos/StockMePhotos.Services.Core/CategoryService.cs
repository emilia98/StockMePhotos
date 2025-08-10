using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMePhotos.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryListViewModel>> ListAllAsync()
        {
           List<CategoryListViewModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new CategoryListViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return allCategories;
        }

        public Task<CategoryListViewModel> ListAllWithDeleted()
        {
            throw new NotImplementedException();
        }
    }
}
