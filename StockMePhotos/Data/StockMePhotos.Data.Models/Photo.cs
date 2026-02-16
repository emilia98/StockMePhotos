using StockMePhotos.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StockMePhotos.Data.Common.EntityConstants;
using static StockMePhotos.Data.Common.DataValidation.Photo;
using Microsoft.AspNetCore.Identity;

namespace StockMePhotos.Data.Models
{
    public class Photo : BaseDeletableModel<Guid>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(SlugMaxLength)]
        public string Slug { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = DateTimeColumnType)]
        public DateTime DateAdded { get; set; }

        [Column(TypeName = DateTimeColumnType)]
        public DateTime? LastModified { get; set; } = null;

        // UserId
        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = null!;

        // IdentityUser
        public virtual IdentityUser User { get; set; } = null!;

        public virtual PhotoUpload? PhotoUpload { get; set; }

        public virtual ICollection<PhotoCategory> PhotoCategories { get; set; } = new List<PhotoCategory>();
    }
}