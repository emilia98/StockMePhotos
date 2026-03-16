namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoCategoryService
    {
        Task AddCategoryToPhotoAsync(string photoId, int categoryId);

        Task RemoveCategoryFromPhotoAsync(string photoId);
    }
}
