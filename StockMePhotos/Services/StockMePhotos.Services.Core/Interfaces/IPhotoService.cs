using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoViewModel?> GetById(string id);

        Task<IEnumerable<PhotoViewModel>> GetAll();

        // Task<PhotoDetailsViewModel?> GetDetails(string id);

        Task AddNewPhoto(AddPhotoInputModel inputModel, string userId);
    }
}
