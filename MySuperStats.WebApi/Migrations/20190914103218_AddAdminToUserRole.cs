using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddAdminToUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "c8e7495f-e5bb-4067-b580-1aa274bef81e");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "2017fef0-7901-4e64-8482-94c1b090d106");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "e40533f2-acbd-48ec-b209-dbec4754930b");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "023b5948-3db6-4f0e-b38b-ee1eb3117213");

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "user_id", "role_id" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "08166285-4926-400b-8ffc-7857e50cf6e2");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "bbca4031-9b4f-4b6f-990a-752af88c7bcc");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "4ce6b4c8-88a4-4c12-b241-16db3cb5ba22");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "7e796633-2380-41b5-a8c3-7deac22e9f23");
        }
    }
}
