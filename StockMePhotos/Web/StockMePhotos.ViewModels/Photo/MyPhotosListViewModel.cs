namespace StockMePhotos.ViewModels.Photo
{
    public class MyPhotosListViewModel
    {
        public IEnumerable<PhotoViewModel> AllPhotos { get; set; } = new List<PhotoViewModel>();
    }
}
