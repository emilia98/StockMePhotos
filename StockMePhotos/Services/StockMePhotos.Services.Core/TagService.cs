using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using StockMePhotos.GCommon.Exceptions;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Services.Core
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public async Task<bool> CreateTagAsync(TagFormModel formModel, string slug)
        {
            Tag newTag = new Tag
            {
                Name = formModel.Name,
                Slug = slug
            };

            return await tagRepository.AddTagAsync(newTag);
        }

        public async Task<IEnumerable<TagViewModel>> GetAllTagsOrderedById()
        {
            IEnumerable<Tag> allTagsFromDb = await tagRepository
                .GetAllTagsAsync(t => t.Id);

            return allTagsFromDb.Select(t => new TagViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Slug = t.Slug,
                PhotosCount = t.PhotoTags.Count
            });
        }

        public async Task<IEnumerable<TagViewModel>> GetAllTagsOrderedByName()
        {
            IEnumerable<Tag> allTagsFromDb = await tagRepository
                .GetAllTagsAsync(t => t.Name);

            return allTagsFromDb.Select(t => new TagViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Slug = t.Slug,
                PhotosCount = t.PhotoTags.Count
            });
        }

        public async Task<bool> TagWithSlugExistsAsync(string slug)
        {
            return await tagRepository.TagWithSlugExistsAsync(slug);
        }

        public async Task<bool> TagWithIdExistsAsync(int id)
        {
            return await tagRepository.TagWithIdExistsAsync(id);
        }

        public async Task<UpdateTagFormModel?> GetTagToUpdateByIdAsync(int tagId)
        {
            Tag? tagFromDb = await tagRepository.GetTagByIdAsync(tagId);

            if (tagFromDb == null)
            {
                return null;
            }

            UpdateTagFormModel updateTagFormModel = new UpdateTagFormModel
            {
                Id = tagFromDb.Id,
                Name = tagFromDb.Name,
                Slug = tagFromDb.Slug,
                DateCreated = tagFromDb.DateAdded.ToString()
            };

            return updateTagFormModel;

        }
        public async Task<bool> UpdateTagAsync(int tagId, string slug)
        {
            Tag? tagToUpdate = await tagRepository.GetTagByIdAsync(tagId);

            if (tagToUpdate == null)
            {
                throw new EntityNotFoundException();
            }

            Tag? tagWithSlug = await tagRepository.TagWithSlugAsync(slug);

            if (tagWithSlug != null && tagWithSlug.Id != tagId)
            {
                throw new EntityAlreadyExistsException();
            }

            if (tagToUpdate.Slug == slug)
            {
                return true;
            }

            tagToUpdate.Slug = slug;
            return await tagRepository.UpdateTagAsync(tagToUpdate);
        }
    }
}
