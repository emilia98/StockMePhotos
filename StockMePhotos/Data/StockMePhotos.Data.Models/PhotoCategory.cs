using StockMePhotos.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMePhotos.Data.Models
{
    public class PhotoCategory : BaseModel<int>
    {
        [Required]
        [ForeignKey(nameof(Photo))]
        public Guid PhotoId { get; set; }

        public virtual Photo Photo { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
