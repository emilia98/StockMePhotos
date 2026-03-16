namespace StockMePhotos.Services.Core.Interfaces
{
    public interface IPhotoUploadService
    {
        Task AddPhotoUploadAsync(Guid photoId, string imageURL);
    }
}
