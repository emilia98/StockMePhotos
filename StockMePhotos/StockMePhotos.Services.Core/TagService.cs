using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data;
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
    }
}
