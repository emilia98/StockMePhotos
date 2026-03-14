namespace StockMePhotos.ViewModels.Photo
{
    public class PhotoViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? ImageURL { get; set; }

        public IEnumerable<string> Categories { get; set; } = new List<string>();
    }
}
