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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ccc67ed-7d84-4bd8-9c91-c54b7d024cb4", "AQAAAAIAAYagAAAAEMWL+PBGZq2i5yyi8HcFH3y3TiHs0n3csLr/YOPC+iJ/9rciU69vHSUYp1CGSO7Pog==", "8b22c085-3e36-4c56-b45d-e047b1c96be5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ea21dc7-1283-4ebb-8f9f-c62f54696b5d", "AQAAAAIAAYagAAAAEM0J4f4m6YWcLwPgpgUX0Hxdeno/mqRcLcgH/eCsD7jTk8I3+TvsOxWuG8BqVR5p9w==", "1a983f14-e466-4076-93c9-d20e702ff93d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1fc88c-fce0-49ba-8dc2-62e0753d543e", "AQAAAAIAAYagAAAAEEjAkwd8se2Ke21Zap1+e2G/7blOdgXJIK+IzwghvPO75VLDAy/yFJBulQ5pER67Lg==", "6f3bad2b-002b-4954-8042-4394f2f5d2f6" });

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "944f59f2-99a0-447b-a482-c12ec5499f40", "AQAAAAIAAYagAAAAEJccxThyM2rNND2AEemxIftAl0eTcVp5s2H/CSgqy6qINftpr3Rh9qmp9XvwGuUaIw==", "59144c90-94e2-4e43-b629-63b18ae66da3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6d25781-3131-463c-8940-e678f228cfe1", "AQAAAAIAAYagAAAAEE2cHlLYOXvyITkmlMwW5CptLtDTSlTqbrKD2l7eXbQWfH2vO76aOVwXCM2JrJRRQQ==", "8c6e8ef0-1415-4582-b2bb-609751e93cec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c446fed-1662-4b13-b64d-4bfcf37c2e4d", "AQAAAAIAAYagAAAAELtDkYxJUYWQCWpBlvwwCWxsyFTe6b8G9qxoNLP3ofA1olh+o6b1yHuW5DazJNAkoQ==", "978a8849-c3a0-41b0-8ba0-5cb841e8ca3a" });
        }
    }
}
