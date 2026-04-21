namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoTagService
    {
        public Task<bool> AddTagToPhotoAsync(string photoId, int tagId);

        public Task<bool> RemoveTagFromPhotoAsync(string photoId, int tagId);

        public Task<bool> HasTagBeenAssigned(int tagId, string photoId);

        public Task<ICollection<int>> GetAllTagsByPhotoAsync(string photoId);

        public Task<IEnumerable<Guid>> GetAllPhotosWithTagAssigned(int tagId);
    }
}
