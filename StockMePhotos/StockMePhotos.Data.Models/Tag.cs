using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models.Base;

namespace StockMePhotos.Data.Models
{
    [Comment("Tag table")]
    public class Tag : BaseDeletableModel<int>
    {
        [Comment("Tag name")]
        public string Name { get; set; } = null!;

        [Comment("Tag slug")]
        public string Slug { get; set; } = null!;
    }
}
