using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.Services.Core.Interfaces;

namespace StockMePhotos.Services.Core
{
    public class PhotoCategoryService : IPhotoCategoryService
    {
        private readonly IPhotoCategoryRepository photoCategoryRepository;

        public PhotoCategoryService(IPhotoCategoryRepository photoCategoryRepository)
        {
            this.photoCategoryRepository = photoCategoryRepository;
        }

        public async Task AddCategoryToPhotoAsync(string photoId, int categoryId)
        {
            bool photoCategoryExists = await photoCategoryRepository.CategoryAssignedToPhotoAsync(categoryId, photoId);

            if (photoCategoryExists) return;

            PhotoCategory newPhotoCategory = new PhotoCategory()
            {
                PhotoId = Guid.Parse(photoId),
                CategoryId = categoryId
            };

            await photoCategoryRepository.AddCategoryToPhotoAsync(newPhotoCategory);
        }

        public async Task<IEnumerable<Guid>> GetAllPhotosWithCategoryAssigned(int categoryId)
        {
            IEnumerable<PhotoCategory> photoCategories = await photoCategoryRepository
                .GetAllPhotosWithAssignedCategory(categoryId);
            return photoCategories
                .Select(pc => pc.PhotoId)
                .ToHashSet();
        }

        public async Task RemoveCategoryFromPhotoAsync(string photoId)
        {
            IEnumerable<PhotoCategory> photoCategoriesToRemove = await photoCategoryRepository.GetAllCategoriesAssignedToPhoto(photoId);

            await photoCategoryRepository.RemoveCategoryFromPhotoAsync(photoCategoriesToRemove);
        }
    }
}
