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
                values: new object[] { "f4b8be2d-637c-4fb9-8610-57cf6d45da9c", "AQAAAAIAAYagAAAAEI5uoUZAA77R+XgJiX7DLqDeJcTquv6PXwr/+yOKc/pjyDyh0hDkYyeojDOJuem52w==", "5dc88923-1cba-4713-837c-df2fe56bba1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4372fa8-7a60-4722-9218-d24358211bdd", "AQAAAAIAAYagAAAAECA2K+1SMghiLc8HAuFAwVjRzIc7VoH7QP5m4YExuG5kabDNX5GM92NS0ZkvQoqw4Q==", "bc91e602-4d2e-4912-b24e-0d3db43c2466" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbae3557-cf90-4787-ba13-e6fa2d985a02", "AQAAAAIAAYagAAAAEBSUIP8UICk7BoOAc4cF8j+bgsvKcILkj70q9XlzamnFbcfcB/Gjc6HnFeNHoQRXGA==", "8d2715e7-d2bd-4b28-a21c-66b4c6aa54c7" });

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
                values: new object[] { "2404cc2c-8291-410e-9415-1ca606f19eac", "AQAAAAIAAYagAAAAEFBaUFojGHhxaG+Q0pMopEx1CvUo51E20XrQSnGdjz7+ku/n/p+VBBKTW1fAzc6DfQ==", "67bce6d2-72a3-47ca-b3a2-e8e00d153967" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f04b29b0-22e7-41dd-ae60-70432a271fda", "AQAAAAIAAYagAAAAEIwMG2RC+KYbgA02uKwmAPE8ljVzhn/EbLRdSAYmxgSSJQ2eeqdvfRTWN+8rYc4Epg==", "95513282-222b-4a4d-a119-c7028a3293d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d51a86d4-bcff-4465-ba06-3666402af7eb", "AQAAAAIAAYagAAAAEIk1D+xJb4Wb3nhcGtU9LZ/WwgnXyxf10LxwV6lZzifhzR+KqXmwnDWtoFkjs4ISFQ==", "cf6d6de4-6eb9-4744-b322-6d6006440a5d" });
        }
    }
}
