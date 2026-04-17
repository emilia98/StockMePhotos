using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhotosTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf96d1b5-38bb-4b89-b92d-7e8ff08f8dc5", "AQAAAAIAAYagAAAAED2XPI806aQ879rXadSL7lXYYEMlGGSHjan7X0uWiLHFbhXTZ5a+aGVCnsv8ZcBAKw==", "849950bf-ed25-4d5f-9002-6f140df55592" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "517101e5-950e-4bc4-a8ce-ac3a2af6898b", "AQAAAAIAAYagAAAAEFk8Gb76nTkep+cQhk6IPpIGiVVv3SMrv3/8dtL3IPUHTDdXRBZncVJVu8PeO+2NfQ==", "e62e6a45-9f6e-4d61-85f8-67831d582190" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e93d2084-b100-42ce-a6af-3c65d5fe66be", "AQAAAAIAAYagAAAAEFdTCsexc38IKR9FVwmc9jxaLR/dVS4VWb77JwjdS5KHUXy3oxAyOWXCOn6UQI2H/g==", "7cf3754c-d467-4b2f-ae27-a41b20399e8e" });

            migrationBuilder.InsertData(
                table: "PhotosTags",
                columns: new[] { "Id", "PhotoId", "TagId" },
                values: new object[,]
                {
                    { 1, new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"), 11 },
                    { 2, new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"), 12 },
                    { 3, new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c"), 11 },
                    { 4, new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c"), 12 },
                    { 5, new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22"), 12 },
                    { 6, new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22"), 15 },
                    { 7, new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"), 5 },
                    { 8, new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"), 10 },
                    { 9, new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"), 15 },
                    { 10, new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481"), 13 },
                    { 11, new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"), 11 },
                    { 12, new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"), 12 },
                    { 13, new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"), 10 },
                    { 14, new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"), 14 },
                    { 15, new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"), 4 },
                    { 16, new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"), 13 },
                    { 17, new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"), 4 },
                    { 18, new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"), 13 },
                    { 19, new Guid("cef5077c-120a-4940-9db5-12781982d2f3"), 12 },
                    { 20, new Guid("cef5077c-120a-4940-9db5-12781982d2f3"), 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PhotosTags",
                keyColumn: "Id",
                keyValue: 20);

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
        }
    }
}
