using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddMatchGroupIdToMatchesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "match_group_id",
                table: "matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "match_groups",
                columns: new[] { "id", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "group_name", "status", "update_date_time", "update_user_id" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "Provus Basketbol", 0, null, null });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "e86c50f1-0287-4db9-a0ef-eefcd66f4123");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "50435398-6f51-48f8-aeaa-8e5d2e0b9b08");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "match_groups",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "match_group_id",
                table: "matches");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "60ac0922-28fd-455f-a599-7f16465a5e18");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "21e48d32-43bc-4ceb-ab2e-11f3dea0b7d7");
        }
    }
}
