using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockMePhotos.Data.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        private readonly PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

        public void Configure(EntityTypeBuilder<IdentityUser> entity)
        {
            entity
                .HasData(SeedUsers());
        }

        private IEnumerable<IdentityUser> SeedUsers()
        {
            IEnumerable<IdentityUser> users = new List<IdentityUser>
            {
                CreateUser("0bb23ace-c418-4314-b8bb-09b3aeb9ab07", "user1", "user1@example.com", "user1.1234"),
                CreateUser("97dfe4b4-8f5b-4a44-971d-6f62037bcde5", "emilia", "emilia@example.com", "emilia.1234"),
                CreateUser("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323", "WhaTheFuck", "WhaTheFuck@example.com", "WhaTheFuck.1234")
            };

            return users;
        }

        private IdentityUser CreateUser(string id, string username, string email, string password)
        {
            var user = new IdentityUser
            {
                Id = id,
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            user.PasswordHash = passwordHasher.HashPassword(user, password);
            
            return user;
        }
    }
}
