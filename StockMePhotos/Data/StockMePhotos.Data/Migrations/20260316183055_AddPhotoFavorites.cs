using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoritePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Entity ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePhotos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoritePhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "FavoritePhotos",
                columns: new[] { "Id", "PhotoId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"), "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323" },
                    { 2, new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"), "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323" },
                    { 3, new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"), "97dfe4b4-8f5b-4a44-971d-6f62037bcde5" },
                    { 4, new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"), "0bb23ace-c418-4314-b8bb-09b3aeb9ab07" },
                    { 5, new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"), "0bb23ace-c418-4314-b8bb-09b3aeb9ab07" },
                    { 6, new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"), "0bb23ace-c418-4314-b8bb-09b3aeb9ab07" },
                    { 7, new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"), "97dfe4b4-8f5b-4a44-971d-6f62037bcde5" },
                    { 8, new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"), "97dfe4b4-8f5b-4a44-971d-6f62037bcde5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePhotos_PhotoId_UserId",
                table: "FavoritePhotos",
                columns: new[] { "PhotoId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePhotos_UserId",
                table: "FavoritePhotos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritePhotos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92465f07-ec79-4301-95fd-64e59a60d69b", "AQAAAAIAAYagAAAAEH+DGi0yRQXh7GKUHt9jA02UggJbuPdK9dyVLNUdFHUDkVfFurnavS11GJY4EO8D0g==", "87c307c2-6554-4994-b85d-4e26089202a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a16bf3bf-4efc-4d46-a5ab-52dbb7a5a73b", "AQAAAAIAAYagAAAAEPzmLacL+yrwffm4BBWi+5eyFWat66Ux8o6WqVbzxMV7ITrLEgMNJ4SIFxN0ET7A0g==", "01ebb87e-0155-49db-bdea-699533a3e9f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9b984a3-53e7-46c3-bdd4-01dbfa00e98f", "AQAAAAIAAYagAAAAEMWj0D8BihvPdHvlsC4u011IIIWwyPFF4y0nWI/rMlunQK2D5Qg07+Pe6rie7m/uOA==", "a403e2e3-0509-4579-bb52-b56c0ffd35b0" });
        }
    }
}
