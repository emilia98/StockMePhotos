using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagViewModel>> GetAllTagsOrderedById();

        Task<IEnumerable<TagViewModel>> GetAllTagsOrderedByName();

        Task<bool> TagWithSlugExistsAsync(string slug);

        Task<int> CreateTagAsync(string name, string slug);

        Task<bool> TagWithIdExistsAsync(int id);

        Task<bool> UpdateTagAsync(int tagId, string slug);

        Task<UpdateTagFormModel?> GetTagToUpdateByIdAsync(int tagId);

        Task<TagViewModel?> GetTagBySlugAsync(string slug);

        Task<bool> RemoveTagAsync(int tagId);
    }
}
