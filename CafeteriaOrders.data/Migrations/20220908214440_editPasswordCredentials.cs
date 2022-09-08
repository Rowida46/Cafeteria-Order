using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeteriaOrders.data.Migrations
{
    public partial class editPasswordCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e5b0c77f-0b42-4fef-ab0b-ace409b33394", "91e0da7e-0a65-4205-a7c2-c38f89816f59", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "624b2a93-bd4d-4379-a57f-f1174b24f410", "669f1213-a366-40ab-ad31-f26a48ad2484", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624b2a93-bd4d-4379-a57f-f1174b24f410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5b0c77f-0b42-4fef-ab0b-ace409b33394");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d40931aa-dbb4-457c-8f5c-5b3c5b2d7f3e", "50a174b6-39b1-45c7-80e1-bdf3cf0eb338", "SuperAdmin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e821543e-a264-4138-a26b-30b30840ca8e", "c0c88646-c7f7-4d98-a041-0075a861336c", "admin", "ADMIN" });
        }
    }
}
