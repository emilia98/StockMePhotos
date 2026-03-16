namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoCategoryService
    {
        Task AddCategoryToPhotoAsync(Guid photoId, int categoryId);
    }
}
