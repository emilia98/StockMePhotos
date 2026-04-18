using Microsoft.AspNetCore.Identity;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Seeding.Contracts;
using static StockMePhotos.GCommon.GlobalSettings;
using static StockMePhotos.GCommon.ExceptionMessages.Identity;

namespace StockMePhotos.Data.Seeding
{
    public class UsersToRolesSeeder : IUsersToRolesSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersToRolesSeeder(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task AssignRolesAsync(ApplicationUser admin, ApplicationUser editor)
        {
            await AssignRole(admin, AdminRoleName);
            await AssignRole(editor, EditorRoleName);
        }

        private async Task AssignRole(ApplicationUser user, string role)
        {
            bool isUserInRole = await userManager.IsInRoleAsync(user, role);

            if (!isUserInRole)
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, role);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(string.Format(RoleAssignFailureExceptionMessage, user.Email, role));
                }
            }
        }
    }
}
