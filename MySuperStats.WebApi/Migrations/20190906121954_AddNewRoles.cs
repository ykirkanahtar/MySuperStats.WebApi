using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddNewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "249642f1-63e0-41b3-bfbb-fc3f42df3cde");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "93baaa91-d0ad-4b35-a93d-8fcd404f0203", "GroupAdmin", "GROUPADMIN" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "status" },
                values: new object[,]
                {
                    { 3, "92db40a2-548a-420a-9b96-abf2ca7d668d", "Editor", "EDITOR", 1 },
                    { 4, "498fb71b-b77d-444a-843f-f7063e0d0be0", "Player", "PLAYER", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "d7c32d17-8f5e-4ee8-81b3-dbdf46bd9e9f");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "62d53525-bb70-4c92-9f83-2d9459262d81", "Player", "PLAYER" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "user_id", "role_id", "match_group_id" },
                values: new object[] { 1, 2, 1 });
        }
    }
}
