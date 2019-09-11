using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class UserRoleKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "96636f89-d564-49ab-88e0-f04fb5e27340");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "58fae60b-0f6b-45c4-b2a4-4e7ac5e323cb");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "d02b2d23-c82a-48a7-8f48-23d94c8337c7");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "9f2bf02a-6df4-4125-9303-48ac0949a36b");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id_role_id_match_group_id",
                table: "user_roles",
                columns: new[] { "user_id", "role_id", "match_group_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_roles_user_id_role_id_match_group_id",
                table: "user_roles");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "7e952b7f-7563-48d3-be58-b49a81b4ac0a");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "8ec24740-a5de-4b75-9b4b-8254549881d7");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "914d04e1-0b1a-4854-a3a6-99a6502a6ea9");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "c222fb37-d3ca-4ca1-8e6b-0de13e97764c");
        }
    }
}
