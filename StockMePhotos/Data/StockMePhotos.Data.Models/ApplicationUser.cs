using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static StockMePhotos.Data.Common.DataValidation.ApplicationUser;

namespace StockMePhotos.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        public virtual ICollection<FavoritePhoto> FavoritePhotos { get; set; } = new List<FavoritePhoto>();

        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
