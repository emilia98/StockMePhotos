using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetPhotoTagModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotosTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Entity ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosTags_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a19b50ee-ab56-446c-8c15-0a09d40f73ca", "AQAAAAIAAYagAAAAEOOAjqUYev/3/7s/nJwo60+3tCJFBinb6QX5r/YDoBDRszm+EOugwI5gG/fpwFiTtQ==", "5295bd71-915e-4950-9952-33146b31f6af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41d78de2-d0eb-4c56-8cb7-90344027c6d2", "AQAAAAIAAYagAAAAEC1OD4fNSou2YxTHRpqKcqnCrObPDZagwD3ZwwqQTp0xErC+O7Fddq9fgg/6nbMWAQ==", "5f060da9-5ebd-48a0-8ecd-48e8bfead515" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d967a09c-a1c1-4a6c-b997-40be440786dc", "AQAAAAIAAYagAAAAEKzd3VtKQAdePmZHyEp2qpxyi1+0MgiI1ivKqmf8mLyN4oT4Hdb/P4aya6MJCttZHA==", "f90ae922-cede-4009-847b-79db08eeccef" });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosTags_PhotoId_TagId",
                table: "PhotosTags",
                columns: new[] { "PhotoId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotosTags_TagId",
                table: "PhotosTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosTags");

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
        }
    }
}
