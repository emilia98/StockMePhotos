using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Repositories.Contracts;
using System.Linq.Expressions;

namespace StockMePhotos.Data.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(StockMePhotosDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<int> AddTagAsync(Tag tag)
        {
            await DbContext!.Tags.AddAsync(tag);
            int resultCount = await SaveChangesAsync();

            // return resultCount == 1;
            return tag.Id;
        }

        public async Task<bool> DeleteTagAsync(Tag tag)
        {
            DbContext!.Tags.Remove(tag);
            int resultCount = await SaveChangesAsync();
            return resultCount == 1;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync<TKey>(Expression<Func<Tag, TKey>> orderBy)
        {
            return await DbContext!
                .Tags
                .AsNoTracking()
                .OrderBy(orderBy)
                .Include(t => t.PhotoTags)
                .ToListAsync();
        }

        public IQueryable<Tag> GetAllTagsNoTracking()
        {
            return DbContext!
                .Tags
                .AsNoTracking();
        }

        public async Task<Tag?> GetTagByIdAsync(int id)
        {
            return await DbContext!.Tags
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag?> GetTagBySlugAsync(string slug)
        {
            return await DbContext!.Tags
                .FirstOrDefaultAsync(t => t.Slug == slug);
        }

        public async Task<bool> TagWithSlugExistsAsync(string slug)
        {
            return await DbContext!.Tags
                .AnyAsync(t => t.Slug == slug);
        }

        public async Task<bool> TagWithIdExistsAsync(int id)
        {
            return await DbContext!.Tags
                .AnyAsync(t => t.Id == id);
        }

        public async Task<Tag?> TagWithSlugAsync(string slug)
        {
            return await DbContext!
                .Tags
                .FirstOrDefaultAsync(t => t.Slug == slug);
        }

        public async Task<bool> UpdateTagAsync(Tag updatedTag)
        {
            DbContext!.Tags.Update(updatedTag);
            int resultCount = await SaveChangesAsync();

            return resultCount == 1;
        }
    }
}
