using StockMePhotos.Services.Common.Contracts;

namespace StockMePhotos.Services.Common
{
    public class SlugGenerator : ISlugGenerator
    {
        public string GenerateSlug(string input)
        {
            string[] inputDataSplit = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLowerInvariant())
                .ToArray();

            return string.Join("-", inputDataSplit);
        }

        public string ReGenerateSlug(string input)
        {
            string[] inputDataSplit = input.Replace("-", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim().ToLowerInvariant())
                .ToArray();

            return string.Join("-", inputDataSplit);
        }
    }
}
