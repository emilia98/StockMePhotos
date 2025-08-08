namespace StockMePhotos.Data.Models.Base
{
    public abstract class BaseModel<TKey>
        where TKey : struct
    {
        protected TKey Id { get; set; }
    }
}
