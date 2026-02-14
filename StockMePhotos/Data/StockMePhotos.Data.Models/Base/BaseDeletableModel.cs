using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StockMePhotos.Data.Models.Base
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>
        where TKey : struct
    {
        [Comment("Entity IsDeleted flag")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}