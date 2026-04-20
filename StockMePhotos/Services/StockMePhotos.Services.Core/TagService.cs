using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
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
    }
}
