using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendTagsSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2dc107d-f46a-4f55-97e8-8bd4817fb076", "AQAAAAIAAYagAAAAECR8RNsjdpjPiU5kIk3sw5npWFDSE4B+IDIuq+1i+R0HHiXEz1Z9SiPjBsHl8kFyYA==", "a1973a19-f5a0-4479-9498-3a1ae4fca25d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81bb066b-2dfa-4d7e-8816-567e4414963a", "AQAAAAIAAYagAAAAELT+NxDFuT3UOTbxueEfZq3rEw8sNVWrh9hDhJ5P4rgcJEuUsxIXT/8PaiWVyt0U1g==", "28a23930-8262-4c27-a0c5-5549ab81e849" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abaa29a6-f819-4dff-9765-32263935f237", "AQAAAAIAAYagAAAAEAHfBf/oWgoPibj6g1MIWcW5qs5+/XXztzuHmAttkJc6jaMajOzh1GZiJHLvMyBQZg==", "007daeeb-f822-4dee-9fb5-6a3584016f75" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 11, "Animal", "animal" },
                    { 12, "Nature", "nature" },
                    { 13, "Architecture", "architecture" },
                    { 14, "Stadium", "stadium" },
                    { 15, "Landscape", "landscape" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32cd542f-1453-439e-ae1c-307aac3c9d03", "AQAAAAIAAYagAAAAEBDVgMVWpyRbpuMPyYs+OowGDcjU9+a6OxF0vn+3rMGZ7XVom7hybqwwVmmoFZDUPQ==", "ad80ce5f-b024-4341-b7fc-6bdd5e1c45d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c334a68-340a-4574-bc5f-04801022e9ad", "AQAAAAIAAYagAAAAEORm3LnQ5hSUfqVmu68cIwXRpG9P3qLAhoZm/KMbTiQdlscIGbNjjehdfeH+5sceig==", "8a839d14-7e54-4eee-ad4b-6380bce34141" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7328429d-954b-4ae1-9071-c5244b7c2730", "AQAAAAIAAYagAAAAEGv7Eg62OhS+O2o1/hCJWO9nOGIqxsU/uPJEtxX3S8UeSW9kF2Hn1ffyGhqqbfdSdQ==", "77e87a31-683f-478e-81d0-85d11f01d599" });
        }
    }
}
