using Microsoft.AspNetCore.Identity;
using StockMePhotos.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace StockMePhotos.Data.Models
{
    public class FavoritePhoto : BaseModel<int>
    {
        [Required]
        // [ForeignKey(nameof(Photo))]
        public Guid PhotoId { get; set; }

        public virtual Photo Photo { get; set; } = null!;

        [Required]
        // [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
