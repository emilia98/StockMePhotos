using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Seeding.Contracts
{
    public interface IUsersSeeder
    {
        Task<(ApplicationUser admin, ApplicationUser editor)> SeedUsersAsync();
    }
}
