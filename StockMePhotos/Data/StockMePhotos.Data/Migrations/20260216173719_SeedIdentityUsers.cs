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
                    { "0bb23ace-c418-4314-b8bb-09b3aeb9ab07", 0, "25af0d88-49cf-47b3-8499-519c86006daa", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEMnO1rTh4ELZ4S+7RzgNIxqvWsM6kPjOMFeiyKZAa3Z5VAkte5MZ2PrU3xXNWTbwHQ==", null, false, "345b0b55-5128-4289-896c-348fc5dc65ca", false, "user1" },
                    { "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323", 0, "3a108499-bd86-490b-b61a-028d3e616791", "WhaTheFuck@example.com", true, false, null, "WHATHEFUCK@EXAMPLE.COM", "WHATHEFUCK", "AQAAAAIAAYagAAAAEMPM9y3UNV/iP2iHZ+1I2MAeXpSK01IOKeXdLQvox3p+OwUbHfGV+jIZHW8N498LJA==", null, false, "701d7e32-eb6c-4dbc-9b16-2a2aad016037", false, "WhaTheFuck" },
                    { "97dfe4b4-8f5b-4a44-971d-6f62037bcde5", 0, "4ba758b0-a6f3-47b8-b469-94adacc19251", "emilia@example.com", true, false, null, "EMILIA@EXAMPLE.COM", "EMILIA", "AQAAAAIAAYagAAAAEL+h52DhKFJ15Y6TLrCICuj3bDE5v2ZP8ommG/mx0Nu1nlInW8eVfrP83Tz7QCA2rQ==", null, false, "725a935e-42c8-43ad-9c56-7b0ec29d153e", false, "emilia" }
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
