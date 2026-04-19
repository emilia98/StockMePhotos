using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.Services.Core.Interfaces;

namespace StockMePhotos.Services.Core
{
    public class PhotoUploadService : IPhotoUploadService
    {
        private readonly IPhotoUploadRepository photoUploadRepository;

        public PhotoUploadService(IPhotoUploadRepository photoUploadRepository)
        {
            this.photoUploadRepository = photoUploadRepository;
        }

        public async Task AddPhotoUploadAsync(Guid photoId, string imageURL)
        {
            PhotoUpload newPhotoUpload = new PhotoUpload()
            {
                PhotoId = photoId,
                ImageURL = imageURL
            };

            await photoUploadRepository.AddPhotoUploadAsync(newPhotoUpload);
        }

        public async Task RemovePhotoUploadAsync(string photoId)
        {
            PhotoUpload? photoUpload = await photoUploadRepository.GetPhotoUploadByPhotoAsync(photoId);

            if (photoUpload != null)
            {
                await photoUploadRepository.DeletePhotoUploadAsync(photoUpload);
            }
        }
    }
}
