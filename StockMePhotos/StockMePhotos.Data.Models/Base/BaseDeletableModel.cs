using Microsoft.EntityFrameworkCore;

namespace StockMePhotos.Data.Models.Base
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>
        where TKey : struct
    {
        [Comment("Entity IsDeleted flag")]
        public bool IsDeleted { get; set; }
    }
}
