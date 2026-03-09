using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotosCategoriesJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotosCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Entity ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosCategories_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhotosCategories",
                columns: new[] { "Id", "CategoryId", "PhotoId" },
                values: new object[,]
                {
                    { 1, 8, new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea") },
                    { 2, 8, new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c") },
                    { 3, 1, new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22") },
                    { 4, 9, new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe") },
                    { 5, 5, new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481") },
                    { 6, 8, new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4") },
                    { 7, 7, new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045") },
                    { 8, 5, new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585") },
                    { 9, 5, new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8") },
                    { 10, 1, new Guid("cef5077c-120a-4940-9db5-12781982d2f3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosCategories_CategoryId",
                table: "PhotosCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosCategories_PhotoId_CategoryId",
                table: "PhotosCategories",
                columns: new[] { "PhotoId", "CategoryId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosCategories");
        }
    }
}
