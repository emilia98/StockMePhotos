using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StockMePhotos.Data.Models.Base
{
    public abstract class BaseModel<TKey>
        where TKey : struct
    {
        [Comment("Entity ID")]
        [Key]
        public TKey Id { get; set; }
    }
}