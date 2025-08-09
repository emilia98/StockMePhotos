using Microsoft.EntityFrameworkCore;

namespace StockMePhotos.Data.Models.Base
{
    public abstract class BaseModel<TKey>
        where TKey : struct
    {
        [Comment("Entity ID")]
        public TKey Id { get; set; }
    }
}
