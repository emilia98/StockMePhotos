using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTagAndCategoryIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a4e5539-0994-4458-8f04-2ddf508e4c89", "AQAAAAIAAYagAAAAEPKQHb1ajbLx4uhRdQx9BTTZQ3K2ZErzbDXFrJqgaWQZ4sNWLLMpQ3ZZFqo9oDtKEg==", "4fbd8a46-0c86-4380-8839-5d4717a10d4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af310b06-ba8e-49e4-90dd-e8abbdae1e2b", "AQAAAAIAAYagAAAAELu7kj3+AxVmIZoRFV7PxHmp/ImvPIQOIVkaHntYLptFSUR/JfkF7HLiRaKhZk6VmA==", "ebe8fb5d-2d00-4fc4-9b60-14dd40acf51e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0bd9ce1-a5c1-4ade-baff-264385e937fd", "AQAAAAIAAYagAAAAEO7UhdRwG77tsFQDNC39W5aA2vnFKoNyHJK/X7y3j3thQ69Cm81ybydHpM7VH18C/w==", "4ca2fd93-d43c-4020-8ff3-3bbf4832e310" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Slug",
                table: "Tags",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                table: "Categories",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tags_Slug",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Slug",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ccc67ed-7d84-4bd8-9c91-c54b7d024cb4", "AQAAAAIAAYagAAAAEMWL+PBGZq2i5yyi8HcFH3y3TiHs0n3csLr/YOPC+iJ/9rciU69vHSUYp1CGSO7Pog==", "8b22c085-3e36-4c56-b45d-e047b1c96be5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ea21dc7-1283-4ebb-8f9f-c62f54696b5d", "AQAAAAIAAYagAAAAEM0J4f4m6YWcLwPgpgUX0Hxdeno/mqRcLcgH/eCsD7jTk8I3+TvsOxWuG8BqVR5p9w==", "1a983f14-e466-4076-93c9-d20e702ff93d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1fc88c-fce0-49ba-8dc2-62e0753d543e", "AQAAAAIAAYagAAAAEEjAkwd8se2Ke21Zap1+e2G/7blOdgXJIK+IzwghvPO75VLDAy/yFJBulQ5pER67Lg==", "6f3bad2b-002b-4954-8042-4394f2f5d2f6" });
        }
    }
}
