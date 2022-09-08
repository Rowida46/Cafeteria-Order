using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeteriaOrders.data.Migrations
{
    public partial class addBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02a54aaa-7824-48ca-9c8e-f9fa3c6bc545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41447b26-794f-4d5d-a690-b1ba28e940bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5aeb4af-48ef-461a-b4cb-a104749bc245", "ac65c1a2-3077-435f-819c-83348fcff975", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28b1af6a-90bb-4077-8a09-609bcbe6fc15", "e62f5495-ff50-4036-8886-fa41cbff6427", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "02a54aaa-7824-48ca-9c8e-f9fa3c6bc545", "8bd7a467-53ec-459b-91bb-8e11f5a85ee3", "Super Admin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41447b26-794f-4d5d-a690-b1ba28e940bb", "c3d170b2-8123-4f47-9f07-1ddb43192805", "admin", "ADMIN" });
        }
    }
}
