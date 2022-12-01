using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class Identityseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7136c732-fd79-4ce5-9888-f9f565e80dde", "92d883d6-573d-4bb4-8777-6a91fbfd498e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af82a6bc-00bf-40aa-affd-d06ddb25b6c3", "5a5a0804-4dc9-4749-8375-e3868fd057f7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3eb36742-7728-45ef-bed2-aaba6058a45b", 0, new DateTime(2022, 11, 30, 9, 34, 36, 458, DateTimeKind.Local).AddTicks(9832), "46bbf0d2-c902-4328-abac-5e54b3fcc7c0", "goran.holmqvist@gmail.com", false, "Göran", "Holmquist", false, null, "GORAN.HOLMQVIST@GMAIL.COM", "GORAN.HOLMQVIST@GMAIL.COM", "AQAAAAEAACcQAAAAEPESGuXxa2yE1w0OOcq2/QLCfcothM+oeafTQLOf48HPgEIV3GaPv9wJP+v7+NWt+w==", null, false, "5fc5aa07-f5b1-4370-96d9-a9faafb60a7a", false, "goran.holmqvist@gamil.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "af82a6bc-00bf-40aa-affd-d06ddb25b6c3", "3eb36742-7728-45ef-bed2-aaba6058a45b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7136c732-fd79-4ce5-9888-f9f565e80dde");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "af82a6bc-00bf-40aa-affd-d06ddb25b6c3", "3eb36742-7728-45ef-bed2-aaba6058a45b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af82a6bc-00bf-40aa-affd-d06ddb25b6c3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3eb36742-7728-45ef-bed2-aaba6058a45b");

        }
    }
}
