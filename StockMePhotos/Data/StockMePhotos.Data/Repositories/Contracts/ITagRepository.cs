using StockMePhotos.Data.Models;
using System.Linq.Expressions;

namespace StockMePhotos.Data.Repositories.Contracts
{
    public interface ITagRepository
    {
        IQueryable<Tag> GetAllTagsNoTracking();

        Task<IEnumerable<Tag>> GetAllTagsAsync<TKey>(Expression<Func<Tag, TKey>> orderBy);

        Task<bool> AddTagAsync(Tag tag);

        Task<bool> DeleteTagAsync(Tag tag);

        Task<Tag?> GetTagByIdAsync(int id);

        Task<bool> TagWithSlugExistsAsync(string slug);

        Task<bool> TagWithIdExistsAsync(int id);

        Task<Tag?> TagWithSlugAsync(string slug);

        Task<bool> UpdateTagAsync(Tag updatedTag);
    }
}
