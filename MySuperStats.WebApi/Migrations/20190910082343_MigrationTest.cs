using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class MigrationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "user_roles",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 1 },
                column: "id",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "user_roles",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 1 },
                column: "id",
                value: 0);
        }
    }
}
