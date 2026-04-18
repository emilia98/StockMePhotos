using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Seeding.Contracts
{
    public interface IUsersToRolesSeeder
    {
        Task AssignRolesAsync(ApplicationUser admin, ApplicationUser editor);
    }
}
