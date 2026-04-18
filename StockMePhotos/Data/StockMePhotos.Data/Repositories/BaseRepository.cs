namespace StockMePhotos.Data.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        private bool isDisposed = false;
        private readonly StockMePhotosDbContext? dbContext;

        protected BaseRepository(StockMePhotosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected StockMePhotosDbContext? DbContext
            => dbContext;

        protected async Task<int> SaveChangesAsync()
        {
            return await DbContext!.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    dbContext?.Dispose();
                }
            }

            isDisposed = true;
        }
    }
}
