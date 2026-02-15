using StockMePhotos.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StockMePhotos.Data.Common.DataValidation.PhotoUpload;

namespace StockMePhotos.Data.Models
{
    public class PhotoUpload : BaseModel<int>
    {
        [Required]
        [MaxLength(ImageURLMaxLength)]
        public string ImageURL { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Photo))]
        public Guid PhotoId { get; set; }

        public virtual Photo Photo { get; set; } = null!;
    }
}
