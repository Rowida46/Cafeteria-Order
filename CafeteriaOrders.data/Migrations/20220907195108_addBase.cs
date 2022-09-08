using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeteriaOrders.data.Migrations
{
    public partial class addBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02a54aaa-7824-48ca-9c8e-f9fa3c6bc545", "8bd7a467-53ec-459b-91bb-8e11f5a85ee3", "Super Admin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41447b26-794f-4d5d-a690-b1ba28e940bb", "c3d170b2-8123-4f47-9f07-1ddb43192805", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02a54aaa-7824-48ca-9c8e-f9fa3c6bc545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41447b26-794f-4d5d-a690-b1ba28e940bb");
        }
    }
}
