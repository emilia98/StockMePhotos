using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface IPhotoTagRepository
    {
        public Task<bool> AddTagToPhotoAsync(PhotoTag photoTag);

        public Task<bool> TagAssignedToPhotoAsync(int tagId, string photoId);

        public Task<IEnumerable<PhotoTag>> GetAllTagsAssignedToPhoto(string photoId);

        public Task<bool> RemoveTagFromPhotoAsync(PhotoTag photoTagToRemove);

        public Task<PhotoTag?> GetPhotoTagByIds(string photoId, int tagId);

        public Task<IEnumerable<PhotoTag>> GetAllPhotosWithAssignedTag(int tagId);
    }
}
