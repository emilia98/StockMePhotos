using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Entity ID"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Image title"),
                    Extension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false, comment: "Image extension"),
                    URL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Image URL"),
                    AltText = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Image alt text")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                },
                comment: "Image table");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
