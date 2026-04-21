using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.GCommon.Exceptions;
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

        public async Task<UpdateCategoryFormModel?> GetCategoryToUpdateByIdAsync(int categoryId)
        {
            Category? categoryFromDb = await categoryRepository.GetCategoryByIdAsync(categoryId);

            if (categoryFromDb == null)
            {
                return null;
            }

            UpdateCategoryFormModel updateCategoryFormModel = new UpdateCategoryFormModel
            {
                Id = categoryFromDb.Id,
                Name = categoryFromDb.Name,
                Slug = categoryFromDb.Slug,
                Description = categoryFromDb.Description,
                DateCreated = categoryFromDb.DateAdded.ToString()
            };

            return updateCategoryFormModel;

        }
        public async Task<bool> UpdateCategoryAsync(int categoryId, string slug, string description)
        {
            Category? categoryToUpdate = await categoryRepository.GetCategoryByIdAsync(categoryId);

            if (categoryToUpdate == null)
            {
                throw new EntityNotFoundException();
            }

            Category? categoryWithSlug = await categoryRepository.CategoryWithSlug(slug);

            if (categoryWithSlug != null && categoryWithSlug.Id != categoryId)
            {
                throw new EntityAlreadyExistsException();
            }

            /*
            if (categoryToUpdate.Slug == slug)
            {
                return true;
            }
            */
            categoryToUpdate.Slug = slug;
            categoryToUpdate.Description = description;

            return await categoryRepository.UpdateCategoryAsync(categoryToUpdate);
        }

        public async Task<bool> RemoveCategoryAsync(int categoryId)
        {
            Category? categoryFromDb = await categoryRepository.GetCategoryByIdAsync(categoryId);

            if (categoryFromDb == null)
            {
                throw new EntityNotFoundException();
            }

            return await categoryRepository.DeleteCategoryAsync(categoryFromDb);
        }
    }
}
