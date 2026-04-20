using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> ListAllCategories()
        {
            IEnumerable<Category> allCategoriesFromDb = await categoryRepository
                .GetAllCategoriesAsync(t => t.Name);

            return allCategoriesFromDb.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOrderedById()
        {
            IEnumerable<Category> allCategoriesFromDb = await categoryRepository
                .GetAllCategoriesAsync(c => c.Id);

            return allCategoriesFromDb.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                PhotosCount = c.PhotoCategories.Count
            });
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesOrderedByName()
        {
            IEnumerable<Category> allCategoriesFromDb = await categoryRepository
                .GetAllCategoriesAsync(t => t.Name);

            return allCategoriesFromDb.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                PhotosCount = c.PhotoCategories.Count
            });
        }
    }
}
