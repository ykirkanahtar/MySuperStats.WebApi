using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class NewUserRolesTableDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "user_roles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "match_group_id",
                table: "user_roles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "42f6ddde-fbd3-4768-84fb-f45ead34b639");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "7035ad98-87f1-487c-913c-5bc1e6388f73");

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 1 },
                column: "match_group_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 2 },
                column: "match_group_id",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "match_group_id",
                table: "user_roles");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "72fced57-a27d-4b6d-b1ca-bfd392b549ec");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "4b380ab4-2d66-4e41-8b7b-917c730f60bf");
        }
    }
}
