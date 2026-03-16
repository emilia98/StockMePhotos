using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<PhotoViewModel> TopPhotos { get; set; } = new List<PhotoViewModel>();

        public IEnumerable<PhotoViewModel> LatestPhotos { get; set; } = new List<PhotoViewModel>();
    }
}
