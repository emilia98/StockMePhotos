using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Services.Core.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagListViewModel>> ListAsync();

        Task AddAsync(TagFormInputModel inputModel);

        Task<TagUpdateInputModel?> GetUpdateDetailsByIdAsync(string? id);

        Task<bool> UpdateAsync(TagUpdateInputModel inputModel);
    }
}
