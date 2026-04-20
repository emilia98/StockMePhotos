using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateCategoryAsync(CategoryFormModel formModel, string slug)
        {
            Category newCategory = new Category
            {
                Name = formModel.Name,
                Slug = slug,
                Description = formModel.Description
            };

            return await categoryRepository.AddCategoryAsync(newCategory);
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

        public async Task<bool> CategoryWithSlugExistsAsync(string slug)
        {
            return await categoryRepository.CategoryWithSlugExists(slug);
        }

        public async Task<bool> CategoryWithIdExistsAsync(int id)
        {
            return await categoryRepository.CategoryWithIdExists(id);
        }
    }
}
