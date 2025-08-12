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
    }
}
