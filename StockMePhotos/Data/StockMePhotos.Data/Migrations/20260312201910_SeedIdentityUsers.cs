using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0bb23ace-c418-4314-b8bb-09b3aeb9ab07", 0, "d87c83ef-160f-471c-aec9-92b73e661bc1", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAELVs1GT92W33h5eVzi15DhLLjIwv44F9L0i1BV/6l33pNSy7FXcm7K7fIVK9ONhkpg==", null, false, "f92808a3-dde2-412d-bba2-876390558253", false, "user1" },
                    { "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323", 0, "795f5137-7278-48cc-8b1c-bd260b5a9d99", "WhaTheFuck@example.com", true, false, null, "WHATHEFUCK@EXAMPLE.COM", "WHATHEFUCK", "AQAAAAIAAYagAAAAECIKRAkYFkDw/YLJG4TaKpNy3ocW4Ht4ciccWNGSu8ied2LLMrmu/Y0cUtfJkUyB7g==", null, false, "526dc255-0435-4339-8e27-8ca247b4c239", false, "WhaTheFuck" },
                    { "97dfe4b4-8f5b-4a44-971d-6f62037bcde5", 0, "f6c2b432-9479-4f05-b581-3f8814d9e3bd", "emilia@example.com", true, false, null, "EMILIA@EXAMPLE.COM", "EMILIA", "AQAAAAIAAYagAAAAEN/3IhuptDSelq7G+d6/Ig/toaSEpQeYc92Crh0Rwa+Sg/Uqtg/E5Ud87+JM6xIEYg==", null, false, "3c072f27-e36c-46ea-8299-b679b470e3b7", false, "emilia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");
        }
    }
}
