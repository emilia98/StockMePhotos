namespace StockMePhotos.ViewModels.Tag
{
    public class TagViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public int PhotosCount { get; set; } = 0;
    }
}
