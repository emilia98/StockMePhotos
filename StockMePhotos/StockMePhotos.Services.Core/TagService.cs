using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
using StockMePhotos.Data.Models;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Services.Core
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<TagListViewModel>> ListAsync()
        {
            IEnumerable<TagListViewModel> allTags = await this.dbContext
                .Tags
                .AsNoTracking()
                .Select(t => new TagListViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return allTags;
        }

        public async Task AddAsync(TagFormInputModel inputModel)
        {
            Tag tagToAdd = new Tag
            {
                Name = inputModel.Name,
                Slug = inputModel.Slug
            };

            await this.dbContext.Tags.AddAsync(tagToAdd);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TagUpdateInputModel?> GetUpdateDetailsByIdAsync(string? id)
        {
            bool isIdParsable = int.TryParse(id, out int tagId);
            if (!isIdParsable)
            {
                return null;
            }

            TagUpdateInputModel? tagFound = await this.dbContext
                .Tags
                .AsNoTracking()
                .Where(t => t.Id == tagId)
                .Select(t => new TagUpdateInputModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Slug = t.Slug
                })
                .SingleOrDefaultAsync();

            return tagFound;
        }

        public async Task<bool> UpdateAsync(TagUpdateInputModel inputModel)
        {
            Tag? editableTag = await this.FindTagByIdAsync(inputModel.Id);
            if (editableTag == null)
            {
                return false;
            }

            editableTag.Name = inputModel.Name;
            editableTag.Slug = inputModel.Slug;

            this.dbContext.Update(editableTag);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Tag?> FindTagByIdAsync(int id)
        {
            Tag? tag = await this.dbContext
                .Tags
                .FirstOrDefaultAsync(t => t.Id == id);
            return tag;
        }
    }
}