using Microsoft.AspNetCore.Identity;
using StockMePhotos.Data.Seeding.Contracts;
using static StockMePhotos.GCommon.ExceptionMessages.Identity;
using static StockMePhotos.GCommon.GlobalSettings;

namespace StockMePhotos.Data.Seeding
{
    public class RolesSeeder : IRolesSeeder
    {
        private readonly string[] ApplicationRoles = new string[]
        {
            AdminRoleName,
            EditorRoleName
        };

        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public RolesSeeder(RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            foreach (string role in ApplicationRoles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var result = await roleManager.CreateAsync(new IdentityRole<Guid>(role));

                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException(string.Format(RoleSeedingExceptionMessage, role));
                    }
                }
            }
        }
    }
}
