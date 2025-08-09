using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Showcases the beauty of the natural world, from lush forests and flowing rivers to flowers and seasonal scenery.", "Nature", "nature" },
                    { 2, "Highlights individuals or groups with a focus on facial expressions, emotions, and personality.\r\n\r\n", "Portrait", "portrait" },
                    { 3, "Captures wide and scenic views of mountains, valleys, oceans, and other breathtaking outdoor vistas.", "Landscape", "landscape" },
                    { 4, "Features wildlife and pets in their natural habitats or playful moments, emphasizing their charm and character.", "Animals", "animals" },
                    { 5, "Depicts everyday life, candid moments, and human interactions across cultures and settings.", "People", "people" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
