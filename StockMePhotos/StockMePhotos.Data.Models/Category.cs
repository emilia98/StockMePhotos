using Microsoft.EntityFrameworkCore;
using StockMePhotos.Data.Models.Base;

namespace StockMePhotos.Data.Models
{
    [Comment("Category table")]
    public class Category : BaseDeletableModel<int>
    {
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        [Comment("Category slug")]
        public string Slug { get; set; } = null!;

        [Comment("Category description")]
        public string Description { get; set; } = null!;
    }
}
