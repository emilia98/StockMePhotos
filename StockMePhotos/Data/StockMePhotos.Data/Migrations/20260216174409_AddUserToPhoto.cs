using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Photos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2404cc2c-8291-410e-9415-1ca606f19eac", "AQAAAAIAAYagAAAAEFBaUFojGHhxaG+Q0pMopEx1CvUo51E20XrQSnGdjz7+ku/n/p+VBBKTW1fAzc6DfQ==", "67bce6d2-72a3-47ca-b3a2-e8e00d153967" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f04b29b0-22e7-41dd-ae60-70432a271fda", "AQAAAAIAAYagAAAAEIwMG2RC+KYbgA02uKwmAPE8ljVzhn/EbLRdSAYmxgSSJQ2eeqdvfRTWN+8rYc4Epg==", "95513282-222b-4a4d-a119-c7028a3293d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d51a86d4-bcff-4465-ba06-3666402af7eb", "AQAAAAIAAYagAAAAEIk1D+xJb4Wb3nhcGtU9LZ/WwgnXyxf10LxwV6lZzifhzR+KqXmwnDWtoFkjs4ISFQ==", "cf6d6de4-6eb9-4744-b322-6d6006440a5d" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22"),
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c"),
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
                column: "UserId",
                value: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
                column: "UserId",
                value: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"),
                column: "UserId",
                value: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"),
                column: "UserId",
                value: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481"),
                column: "UserId",
                value: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cef5077c-120a-4940-9db5-12781982d2f3"),
                column: "UserId",
                value: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Photos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25af0d88-49cf-47b3-8499-519c86006daa", "AQAAAAIAAYagAAAAEMnO1rTh4ELZ4S+7RzgNIxqvWsM6kPjOMFeiyKZAa3Z5VAkte5MZ2PrU3xXNWTbwHQ==", "345b0b55-5128-4289-896c-348fc5dc65ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a108499-bd86-490b-b61a-028d3e616791", "AQAAAAIAAYagAAAAEMPM9y3UNV/iP2iHZ+1I2MAeXpSK01IOKeXdLQvox3p+OwUbHfGV+jIZHW8N498LJA==", "701d7e32-eb6c-4dbc-9b16-2a2aad016037" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba758b0-a6f3-47b8-b469-94adacc19251", "AQAAAAIAAYagAAAAEL+h52DhKFJ15Y6TLrCICuj3bDE5v2ZP8ommG/mx0Nu1nlInW8eVfrP83Tz7QCA2rQ==", "725a935e-42c8-43ad-9c56-7b0ec29d153e" });
        }
    }
}
