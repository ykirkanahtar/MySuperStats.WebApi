using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class RoleNameEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "13a18943-e95b-403b-8feb-98b7493abf70");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "4b02fffb-cfa5-45ac-9b5c-76db24a86125", "PLAYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "f1373b85-d08e-4df9-a71d-6c73b8a9b0c0");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "normalized_name" },
                values: new object[] { "ba2e9986-47f8-4de7-8f74-0601c3a5f8f0", "Player" });
        }
    }
}
