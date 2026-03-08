using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Photos",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Description", "IsDeleted", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"), "Fans cheering inside a packed football stadium.", false, "football-stadium-crowd", "Football Stadium Crowd" },
                    { new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"), "modern-glass-skyscraper", false, "modern-glass-skyscraper", "Modern Glass Skyscraper" },
                    { new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22"), "Clear river flowing between rocks and pine trees.", false, "mountain-river", "Mountain River" },
                    { new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c"), "Wild horse running freely across open fields.", false, "running-horse", "Running Horse" },
                    { new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"), "Majestic lion resting in golden savannah grass.", false, "lion-in-the-wild", "Lion in the Wild" },
                    { new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"), "Powerful eagle soaring high above the mountains.", false, "eagle-in-flight", "Eagle in Flight" },
                    { new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"), "Multi-level pagoda surrounded by autumn trees.", false, "traditional-wooden-pagoda", "Traditional Wooden Pagoda" },
                    { new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"), "Stone temple remains surrounded by jungle.", false, "ancient-temple-ruins", "Ancient Temple Ruins" },
                    { new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481"), "Old arched bridge crossing a calm river.", false, "historic-stone-bridge", "Historic Stone Bridge" },
                    { new Guid("cef5077c-120a-4940-9db5-12781982d2f3"), "Sharp snowy mountain under a clear sky.", false, "snowy-mountain-peak", "Snowy Mountain Peak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cef5077c-120a-4940-9db5-12781982d2f3"));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Photos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);
        }
    }
}
