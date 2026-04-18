using StockMePhotos.Data.Models;
using StockMePhotos.Data.Seeding.Contracts;

namespace StockMePhotos.Data.Seeding
{
    public class IdentitySeeder : IIdentitySeeder
    {
        private readonly IRolesSeeder rolesSeeder;
        private readonly IUsersSeeder usersSeeder;
        private readonly IUsersToRolesSeeder usersToRolesSeeder;

        public IdentitySeeder(IRolesSeeder rolesSeeder,
            IUsersSeeder usersSeeder,
            IUsersToRolesSeeder usersToRolesSeeder)
        {
            this.rolesSeeder = rolesSeeder;
            this.usersSeeder = usersSeeder;
            this.usersToRolesSeeder = usersToRolesSeeder;
        }
        public async Task SeedAsync()
        {
            await rolesSeeder.SeedRolesAsync();

            (ApplicationUser adminUser, ApplicationUser editorUser) = await usersSeeder.SeedUsersAsync();

            await usersToRolesSeeder.AssignRolesAsync(adminUser, editorUser);
        }
    }
}
