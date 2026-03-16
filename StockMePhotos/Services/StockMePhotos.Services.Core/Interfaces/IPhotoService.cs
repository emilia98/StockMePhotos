using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoViewModel?> GetById(string id);

        Task<IEnumerable<PhotoViewModel>> GetAll();

        // Task<PhotoDetailsViewModel?> GetDetails(string id);

        Task<Guid> AddNewPhoto(AddPhotoInputModel inputModel, string userId);

        Task<IEnumerable<PhotoViewModel>> GetAllPhotosByUserAsync(string userId);

        Task<PhotoDetailsViewModel?> GetDetails(string id, string? userId);

        Task<UpdatePhotoInputModel?> GetEntityToUpdateByIdAsync(string id);

        Task<bool> UpdatePhotoEntity(string photoId, UpdatePhotoInputModel inputModel);

        Task<string?> GetPhotoOwnerByPhotoIdAsync(string id);

        Task<bool> DeletePhotoByIdAsync(string photoId);
    }
}
