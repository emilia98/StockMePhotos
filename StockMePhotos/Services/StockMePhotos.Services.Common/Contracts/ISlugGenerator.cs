namespace StockMePhotos.Services.Common.Contracts
{
    public interface ISlugGenerator
    {
        string GenerateSlug(string input);

        string ReGenerateSlug(string input);
    }
}
