using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models.Base;

namespace StockMePhotos.Data.Models
{
    [Comment("Image table")]
    public class Image : BaseModel<Guid>
    {
        [Comment("Image title")]
        public string Title { get; set; } = null!;

        [Comment("Image extension")]
        public string Extension { get; set; } = null!;

        [Comment("Image URL")]
        public string URL { get; set; } = null!;

        [Comment("Image alt text")]
        public string AltText { get; set; } = null!;
    }
}