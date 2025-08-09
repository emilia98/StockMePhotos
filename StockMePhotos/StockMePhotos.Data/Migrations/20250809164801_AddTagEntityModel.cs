using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTagEntityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Entity ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Tag name"),
                    Slug = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Tag slug"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Entity IsDeleted flag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                },
                comment: "Tag table");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
