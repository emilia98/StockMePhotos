using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhotosUploads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PhotoUploads",
                columns: new[] { "Id", "ImageURL", "PhotoId" },
                values: new object[,]
                {
                    { 1, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264895/lion-in-the-wild_y6rzx0.webp", new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea") },
                    { 2, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264382/running-horse_nk2imj.jpg", new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c") },
                    { 3, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264388/mountain-river_qk7yll.avif", new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22") },
                    { 4, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771264699/modern-glass-skyscraper_f11xyq.jpg", new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe") },
                    { 5, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265103/historic-stone-bridge_sncska.jpg", new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481") },
                    { 6, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265186/eagle-in-flight_qykv4v.jpg", new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4") },
                    { 7, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265564/football-stadium-crowd_zvvkso.jpg", new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045") },
                    { 8, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265493/traditional-wooden-pagoda_zq5enw.jpg", new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585") },
                    { 9, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265794/ancient-temple-ruins_xszn2q.jpg", new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8") },
                    { 10, "https://res.cloudinary.com/ddrcfggwn/image/upload/v1771265795/snowy-mountain-peak_njsdu5.jpg", new Guid("cef5077c-120a-4940-9db5-12781982d2f3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PhotoUploads",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
