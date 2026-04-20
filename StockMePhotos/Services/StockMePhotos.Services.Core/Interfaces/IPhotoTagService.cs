namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoTagService
    {
        public Task<bool> AddTagToPhotoAsync(string photoId, int tagId);

        public Task<bool> RemoveTagFromPhotoAsync(string photoId, int tagId);
    }
}
