using StockMePhotos.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMePhotos.Data.Models
{
    public class PhotoTag : BaseModel<int>
    {
        [Required]
        [ForeignKey(nameof(Photo))]
        public Guid PhotoId { get; set; }

        public virtual Photo Photo { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; } = null!;
    }
}
