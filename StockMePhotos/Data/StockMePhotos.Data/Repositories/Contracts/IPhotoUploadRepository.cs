using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface IPhotoUploadRepository
    {
        Task<bool> AddPhotoUploadAsync(PhotoUpload photoUpload);

        Task<bool> DeletePhotoUploadAsync(PhotoUpload photoUpload);

        Task<PhotoUpload?> GetPhotoUploadByPhotoAsync(string photoId);
    }
}
