using StockMePhotos.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StockMePhotos.Data.Common.EntityConstants;
using static StockMePhotos.Data.Common.DataValidation.Tag;

namespace StockMePhotos.Data.Models
{
    public class Tag : BaseModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(SlugMaxLength)]
        public string Slug { get; set; } = null!;

        [Required]
        [Column(TypeName = DateTimeColumnType)]
        public DateTime DateAdded { get; set; }
    }
}