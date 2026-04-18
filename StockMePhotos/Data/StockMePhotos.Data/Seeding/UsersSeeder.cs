using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using StockMePhotos.Data.Models;
using StockMePhotos.Data.Seeding.Contracts;
using static StockMePhotos.GCommon.ExceptionMessages.Identity;
using static StockMePhotos.GCommon.GlobalSettings;

namespace StockMePhotos.Data.Seeding
{
    public class UsersSeeder : IUsersSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public UsersSeeder(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<(ApplicationUser admin, ApplicationUser editor)> SeedUsersAsync()
        {
            SeedUser adminUserData = GetUserData(AdminRoleName);
            SeedUser editorUserData = GetUserData(EditorRoleName);
            IEnumerable<SeedUser> usersConfigData = GetUsersFromConfig();

            ApplicationUser adminUser = await CreateOrUpdateUserAsync(adminUserData);
            ApplicationUser editorUser = await CreateOrUpdateUserAsync(editorUserData);

            foreach (var user in usersConfigData)
            {
                await CreateOrUpdateUserAsync(user);
            }

            return (adminUser, editorUser);
        }

        private async Task<ApplicationUser> CreateOrUpdateUserAsync(SeedUser seedUser)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(seedUser.Email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = seedUser.Username,
                    Email = seedUser.Email,
                };

                IdentityResult result = await userManager.CreateAsync(user, seedUser.Password);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(string.Format(UserSeedingExceptionMessage, seedUser.Email));
                }
            }
            else
            {
                if (user.UserName != seedUser.Username)
                {
                    user.UserName = seedUser.Username;
                    user.NormalizedUserName = seedUser.Username!.ToUpper();
                    await userManager.UpdateAsync(user);
                }

                bool isPasswordValid = await userManager.CheckPasswordAsync(user, seedUser.Password);

                if (!isPasswordValid)
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    string? token = await userManager.GeneratePasswordResetTokenAsync(user);
                    IdentityResult result = await userManager.ResetPasswordAsync(user, token, seedUser.Password);

                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException(string.Format(UserResetPasswordExceptionMessage, seedUser.Email));
                    }
                }
            }

            return user;
        }

        private SeedUser GetUserData(string? userSection = null, IConfigurationSection? configSection = null)
        {
            string? userEmail = string.Empty;
            string? userPassword = string.Empty;
            string? userName = string.Empty;

            if (!string.IsNullOrEmpty(userSection))
            {
                string configUserEmailSection = string.Format("UserSeed:{0}:Email", userSection) ?? string.Empty;
                string configUserPasswordSection = string.Format("UserSeed:{0}:Password", userSection) ?? string.Empty;
                string configUserNameSection = string.Format("UserSeed:{0}:UserName", userSection) ?? string.Empty;
                userEmail = configuration[configUserEmailSection] ?? null;
                userPassword = configuration[configUserPasswordSection] ?? null;
                userName = configuration[configUserNameSection] ?? null;
            }

            if (configSection != null)
            {
                userEmail = configSection["Email"] ?? null;
                userPassword = configSection["Password"] ?? null;
                userName = configSection["UserName"] ?? null;
            }


            if (string.IsNullOrEmpty(userEmail))
            {
                throw new InvalidOperationException(string.Format(EmailNotFoundExceptionMessage, userSection));
            }

            if (string.IsNullOrEmpty(userPassword))
            {
                throw new InvalidOperationException(string.Format(PasswordNotFoundExceptionMessage, userSection));
            }

            if (string.IsNullOrEmpty(userName))
            {
                throw new InvalidOperationException(string.Format(UsernameNotFoundExceptionMessage, userSection));
            }

            SeedUser user = new SeedUser
            {
                Email = userEmail,
                Password = userPassword,
                Username = userName
            };

            return user;
        }

        private IEnumerable<SeedUser> GetUsersFromConfig()
        {
            IConfigurationSection usersSection = configuration
                .GetSection("UserSeed:Users");
            IEnumerable<IConfigurationSection> usersChildSections = usersSection.GetChildren();

            ICollection<SeedUser> users = new List<SeedUser>();

            foreach (IConfigurationSection user in usersChildSections)
            {
                users.Add(GetUserData(null, user));
            }

            if (users == null || users.Count() == 0)
            {
                throw new InvalidOperationException(NoUsersFoundInConfiguration);
            }

            return users!;
        }
    }
}
