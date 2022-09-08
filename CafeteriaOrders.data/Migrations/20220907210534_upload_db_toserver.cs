using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeteriaOrders.data.Migrations
{
    public partial class upload_db_toserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52d6aa73-0baa-4105-8ce7-f56196488dc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f6b1210-b6f3-49ac-824e-3f6c4862256b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d40931aa-dbb4-457c-8f5c-5b3c5b2d7f3e", "50a174b6-39b1-45c7-80e1-bdf3cf0eb338", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e821543e-a264-4138-a26b-30b30840ca8e", "c0c88646-c7f7-4d98-a041-0075a861336c", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d40931aa-dbb4-457c-8f5c-5b3c5b2d7f3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e821543e-a264-4138-a26b-30b30840ca8e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f6b1210-b6f3-49ac-824e-3f6c4862256b", "85660191-a65b-4d08-b00f-d5d0fa18d6d7", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52d6aa73-0baa-4105-8ce7-f56196488dc4", "736cc252-3e05-4913-b6b0-8fbfe1317eca", "admin", "ADMIN" });
        }
    }
}
