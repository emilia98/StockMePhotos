using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMePhotos.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePhotos_AspNetUsers_UserId",
                table: "FavoritePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePhotos_Photos_PhotoId",
                table: "FavoritePhotos");

            // DROP the Photos -> AspNetUsers FK before changes
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            // Drop AspNetUserTokens PK/FK (required for token PK change)
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            // Drop AspNetUsers PK and FKs that reference AspNetUsers.Id so we can alter Id type
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            // ALSO drop AspNetRoles / role-related constraints before altering RoleId / AspNetRoles.Id
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FavoritePhotos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Re-create AspNetUsers PK now that Id is uniqueidentifier
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            // Re-create AspNetUserTokens primary key now that UserId has been changed
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Re-create AspNetRoles PK now that Id is uniqueidentifier
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            // Re-create AspNetUserRoles PK now that RoleId/UserId are updated
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"), 0, "5ac480a0-48c9-4eea-b6fb-7ba7f8e78c14", "user1@example.com", true, null, null, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDpezchkQAEjJ71X25R0fHsU4rUQrSM49lvXfxq2f5FCnkyWjnEbmFTO+UN2mcydvw==", null, false, null, false, "user1" },
                    { new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"), 0, "50db99a6-4108-48f1-8e52-b6ee50c84727", "WhaTheFuck@example.com", true, null, null, false, null, "WHATHEFUCK@EXAMPLE.COM", "WHATHEFUCK@EXAMPLE.COM", "AQAAAAIAAYagAAAAEC2DZ9H+kZeCUmykgkceRHR+QHZAbnkiPgaKrRsV4a/N2YRUWRFd5n281c6D+mmuiw==", null, false, null, false, "WhaTheFuck" },
                    { new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"), 0, "f8f4a6c8-944b-4280-800b-99bd9dbf078a", "emilia@example.com", true, null, null, false, null, "EMILIA@EXAMPLE.COM", "EMILIA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF8XqtLWs9dMOWiZJJhB4WFyeCacLEd72sphn2aaiZSG7Q7Y2VVCBypEjXcWPNemTQ==", null, false, null, false, "emilia" }
                });

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0b1c7a4e-9b2e-4f6c-bc41-d1d6f42c6045"),
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0c71e3e7-b60a-4633-a906-0e996724f4fe"),
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3606010e-60d1-467e-b85f-1c93bd1a2c22"),
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("398ac8ba-b365-495e-95ca-8d2d17c5065c"),
                column: "UserId",
                value: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3c2161d2-92c0-4511-b390-7b3a862d72ea"),
                column: "UserId",
                value: new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("97e1fee6-c879-4b66-a1c2-3804d736cdf4"),
                column: "UserId",
                value: new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b192d3de-8452-4b11-9e2f-fa66a2216585"),
                column: "UserId",
                value: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c0f0fc5a-1a7c-416e-8f00-0a1f4bedead8"),
                column: "UserId",
                value: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("c6031c0d-d5f9-4434-b0ec-b40481613481"),
                column: "UserId",
                value: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cef5077c-120a-4940-9db5-12781982d2f3"),
                column: "UserId",
                value: new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"));

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePhotos_AspNetUsers_UserId",
                table: "FavoritePhotos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePhotos_Photos_PhotoId",
                table: "FavoritePhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");

            // Re-create the Photos -> AspNetUsers FK after the column type change
            migrationBuilder.AddForeignKey(
               name: "FK_Photos_AspNetUsers_UserId",
               table: "Photos",
               column: "UserId",
               principalTable: "AspNetUsers",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);

            // Re-create AspNetUserTokens FK to AspNetUsers
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Re-create AspNetUserRoles/Logins/Claims FKs to AspNetUsers
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Re-create AspNetUserRoles -> AspNetRoles FK and AspNetRoleClaims -> AspNetRoles FK
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
    name: "FK_FavoritePhotos_AspNetUsers_UserId",
    table: "FavoritePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePhotos_Photos_PhotoId",
                table: "FavoritePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            // Drop all AspNetUsers-related FKs and PK before reverting Id to string
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            // Drop role-related FK/PK before reverting RoleId / AspNetRoles.Id
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
               name: "PK_AspNetUserRoles",
               table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
               name: "PK_AspNetRoles",
               table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
               name: "PK_AspNetUserTokens",
               table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
               name: "PK_AspNetUsers",
               table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0bb23ace-c418-4314-b8bb-09b3aeb9ab07"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75e1fd93-5f2d-4e72-8900-6ab9ed9ae323"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97dfe4b4-8f5b-4a44-971d-6f62037bcde5"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Photos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavoritePhotos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            // Re-create AspNetUserTokens PK (string-based) before re-adding its FK
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            // Re-create AspNetUsers PK (string-based)
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0bb23ace-c418-4314-b8bb-09b3aeb9ab07", 0, "cf96d1b5-38bb-4b89-b92d-7e8ff08f8dc5", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAED2XPI806aQ879rXadSL7lXYYEMlGGSHjan7X0uWiLHFbhXTZ5a+aGVCnsv8ZcBAKw==", null, false, "849950bf-ed25-4d5f-9002-6f140df55592", false, "user1" },
                    { "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323", 0, "517101e5-950e-4bc4-a8ce-ac3a2af6898b", "WhaTheFuck@example.com", true, false, null, "WHATHEFUCK@EXAMPLE.COM", "WHATHEFUCK@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFk8Gb76nTkep+cQhk6IPpIGiVVv3SMrv3/8dtL3IPUHTDdXRBZncVJVu8PeO+2NfQ==", null, false, "e62e6a45-9f6e-4d61-85f8-67831d582190", false, "WhaTheFuck" },
                    { "97dfe4b4-8f5b-4a44-971d-6f62037bcde5", 0, "e93d2084-b100-42ce-a6af-3c65d5fe66be", "emilia@example.com", true, false, null, "EMILIA@EXAMPLE.COM", "EMILIA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFdTCsexc38IKR9FVwmc9jxaLR/dVS4VWb77JwjdS5KHUXy3oxAyOWXCOn6UQI2H/g==", null, false, "7cf3754c-d467-4b2f-ae27-a41b20399e8e", false, "emilia" }
                });

            // Re-create FK relationships
            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePhotos_AspNetUsers_UserId",
                table: "FavoritePhotos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePhotos_Photos_PhotoId",
                table: "FavoritePhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "75e1fd93-5f2d-4e72-8900-6ab9ed9ae323");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "0bb23ace-c418-4314-b8bb-09b3aeb9ab07");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

            migrationBuilder.UpdateData(
                table: "FavoritePhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "97dfe4b4-8f5b-4a44-971d-6f62037bcde5");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePhotos_AspNetUsers_UserId",
                table: "FavoritePhotos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePhotos_Photos_PhotoId",
                table: "FavoritePhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
