using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.Services.Core.Interfaces;

namespace StockMePhotos.Services.Core
{
    public class PhotoTagService : IPhotoTagService
    {
        private readonly IPhotoTagRepository photoTagRepository;

        public PhotoTagService(IPhotoTagRepository photoTagRepository)
        {
            this.photoTagRepository = photoTagRepository;
        }

        public async Task<bool> AddTagToPhotoAsync(string photoId, int tagId)
        {
            bool tagAlreadyAssigned = await photoTagRepository.TagAssignedToPhotoAsync(tagId, photoId);

            if (tagAlreadyAssigned)
            {
                return true;
            }

            PhotoTag photoTagEntity = new PhotoTag
            {
                PhotoId = Guid.Parse(photoId),
                TagId = tagId
            };

            return await photoTagRepository.AddTagToPhotoAsync(photoTagEntity);
        }

        public async Task<bool> RemoveTagFromPhotoAsync(string photoId, int tagId)
        {
            PhotoTag? photoTagToRemove = await photoTagRepository.GetPhotoTagByIds(photoId, tagId);

            if (photoTagToRemove == null)
            {
                return true;
            }

            return await photoTagRepository.RemoveTagFromPhotoAsync(photoTagToRemove);
        }

        public async Task<bool> HasTagBeenAssigned(int tagId, string photoId)
        {
            return await photoTagRepository.TagAssignedToPhotoAsync(tagId, photoId);
        }

        public async Task<ICollection<int>> GetAllTagsByPhotoAsync(string photoId)
        {
            IEnumerable<PhotoTag> photoTags =  await photoTagRepository
                .GetAllTagsAssignedToPhoto(photoId);
            return photoTags
                .Select(pt => pt.TagId)
                .ToHashSet();
        }
    }
}
