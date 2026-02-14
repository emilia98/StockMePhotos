using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryDbModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Entity ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Forests, mountains, beaches, sunsets, and outdoor scenery.", "Nature & Landscapes", "nature-landscapes" },
                    { 2, "Meals, desserts, beverages, and restaurant-style photography.", "Food & Drinks", "food-drinks" },
                    { 3, "Everyday moments, portraits, work, family, and social life.", "People & Lifestyle", "people-lifestyle" },
                    { 4, "Offices, devices, startups, teamwork, and digital life.", "Business & Technology", "business-technology" },
                    { 5, "Cities, landmarks, tourism, and cultural locations.", "Travel & Destinations", "travel-destinations" },
                    { 6, "Clothing, accessories, cosmetics, and style trends.", "Fashion & Beauty", "fashion-beauty" },
                    { 7, "Training, workouts, competitions, and active lifestyles.", "Sports & Fitness", "sports-fitness" },
                    { 8, "Pets, farm animals, and wildlife in natural settings.", "Animals & Wildlife", "animals-wildlife" },
                    { 9, "Buildings, homes, offices, and interior design.", "Architecture & Interiors", "architecture-interiors" },
                    { 10, "Painting, music, crafts, design, and creative expression.", "Art & Creativity", "art-creativity" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
