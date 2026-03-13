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
                values: new object[] { "d87c83ef-160f-471c-aec9-92b73e661bc1", "AQAAAAIAAYagAAAAELVs1GT92W33h5eVzi15DhLLjIwv44F9L0i1BV/6l33pNSy7FXcm7K7fIVK9ONhkpg==", "f92808a3-dde2-412d-bba2-876390558253" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "795f5137-7278-48cc-8b1c-bd260b5a9d99", "AQAAAAIAAYagAAAAECIKRAkYFkDw/YLJG4TaKpNy3ocW4Ht4ciccWNGSu8ied2LLMrmu/Y0cUtfJkUyB7g==", "526dc255-0435-4339-8e27-8ca247b4c239" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6c2b432-9479-4f05-b581-3f8814d9e3bd", "AQAAAAIAAYagAAAAEN/3IhuptDSelq7G+d6/Ig/toaSEpQeYc92Crh0Rwa+Sg/Uqtg/E5Ud87+JM6xIEYg==", "3c072f27-e36c-46ea-8299-b679b470e3b7" });
        }
    }
}
