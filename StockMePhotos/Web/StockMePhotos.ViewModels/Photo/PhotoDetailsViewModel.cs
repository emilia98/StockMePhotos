using StockMePhotos.ViewModels.Category;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.ViewModels.Photo
{
    public class PhotoDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DateAdded { get; set; } = null!;

        public string? ImageURL { get; set; }

        public string UserName { get; set; } = null!;

        public string CreatorId { get; set; } = null!;

        public bool IsOwner { get; set; } = false;

        public bool IsInFavoriteList { get; set; } = false;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public IEnumerable<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
    }
}
