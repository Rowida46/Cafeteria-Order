using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeteriaOrders.data.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28b1af6a-90bb-4077-8a09-609bcbe6fc15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5aeb4af-48ef-461a-b4cb-a104749bc245");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f6b1210-b6f3-49ac-824e-3f6c4862256b", "85660191-a65b-4d08-b00f-d5d0fa18d6d7", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52d6aa73-0baa-4105-8ce7-f56196488dc4", "736cc252-3e05-4913-b6b0-8fbfe1317eca", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c5aeb4af-48ef-461a-b4cb-a104749bc245", "ac65c1a2-3077-435f-819c-83348fcff975", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28b1af6a-90bb-4077-8a09-609bcbe6fc15", "e62f5495-ff50-4036-8886-fa41cbff6427", "admin", "ADMIN" });
        }
    }
}
