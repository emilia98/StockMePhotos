using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;

namespace StockMePhotos.Data.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private readonly PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity
                .HasData(SeedUsers());
        }

        private IEnumerable<ApplicationUser> SeedUsers()
        {
            IEnumerable<ApplicationUser> users = new List<ApplicationUser>
            {
                CreateUser("0bb23ace-c418-4314-b8bb-09b3aeb9ab07", "user1", "user1@example.com", "user1.1234"),
                CreateUser("97dfe4b4-8f5b-4a44-971d-6f62037bcde5", "emilia", "emilia@example.com", "emilia.1234"),
                CreateUser("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323", "WhaTheFuck", "WhaTheFuck@example.com", "WhaTheFuck.1234")
            };

            return users;
        }

        private ApplicationUser CreateUser(string id, string username, string email, string password)
        {
            var user = new ApplicationUser
            {
                Id = Guid.Parse(id),
                UserName = username,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
            };

            user.PasswordHash = passwordHasher.HashPassword(user, password);

            return user;
        }
    }
}
