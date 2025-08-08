namespace StockMePhotos.Data.Models.Base
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>
        where TKey : struct
    {
        public bool IsDeleted { get; set; }
    }
}
