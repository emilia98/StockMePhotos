using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagViewModel>> GetAllTagsOrderedById();

        Task<IEnumerable<TagViewModel>> GetAllTagsOrderedByName();
    }
}
