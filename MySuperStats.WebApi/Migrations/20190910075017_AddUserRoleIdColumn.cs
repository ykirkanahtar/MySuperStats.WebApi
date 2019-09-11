using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddUserRoleIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "ae86c9ad-56fa-4c70-a1b0-a0c05d158218");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "95277ba2-9c83-4875-bd76-ea1b21fb0c94");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "8b009415-5d52-4ed2-9878-37686562931c");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "bced8fff-2869-4be9-a0fa-632b964d0005");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "b4c53d34-fdec-4008-a08c-3216d9372976");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "3d1fdd49-a8e2-4883-8150-adcf45672359");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "6e0ee792-19a6-49a6-b051-fbcd5ee95612");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "b7e1936a-dbd2-4c68-ad8d-361f50594f01");
        }
    }
}
