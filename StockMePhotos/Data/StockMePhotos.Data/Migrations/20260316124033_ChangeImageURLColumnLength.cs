using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageURLColumnLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "PhotoUploads",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92465f07-ec79-4301-95fd-64e59a60d69b", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEH+DGi0yRQXh7GKUHt9jA02UggJbuPdK9dyVLNUdFHUDkVfFurnavS11GJY4EO8D0g==", "87c307c2-6554-4994-b85d-4e26089202a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a16bf3bf-4efc-4d46-a5ab-52dbb7a5a73b", "WHATHEFUCK@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPzmLacL+yrwffm4BBWi+5eyFWat66Ux8o6WqVbzxMV7ITrLEgMNJ4SIFxN0ET7A0g==", "01ebb87e-0155-49db-bdea-699533a3e9f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9b984a3-53e7-46c3-bdd4-01dbfa00e98f", "EMILIA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMWj0D8BihvPdHvlsC4u011IIIWwyPFF4y0nWI/rMlunQK2D5Qg07+Pe6rie7m/uOA==", "a403e2e3-0509-4579-bb52-b56c0ffd35b0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "PhotoUploads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a4e5539-0994-4458-8f04-2ddf508e4c89", "USER1", "AQAAAAIAAYagAAAAEPKQHb1ajbLx4uhRdQx9BTTZQ3K2ZErzbDXFrJqgaWQZ4sNWLLMpQ3ZZFqo9oDtKEg==", "4fbd8a46-0c86-4380-8839-5d4717a10d4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af310b06-ba8e-49e4-90dd-e8abbdae1e2b", "WHATHEFUCK", "AQAAAAIAAYagAAAAELu7kj3+AxVmIZoRFV7PxHmp/ImvPIQOIVkaHntYLptFSUR/JfkF7HLiRaKhZk6VmA==", "ebe8fb5d-2d00-4fc4-9b60-14dd40acf51e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0bd9ce1-a5c1-4ade-baff-264385e937fd", "EMILIA", "AQAAAAIAAYagAAAAEO7UhdRwG77tsFQDNC39W5aA2vnFKoNyHJK/X7y3j3thQ69Cm81ybydHpM7VH18C/w==", "4ca2fd93-d43c-4020-8ff3-3bbf4832e310" });
        }
    }
}
