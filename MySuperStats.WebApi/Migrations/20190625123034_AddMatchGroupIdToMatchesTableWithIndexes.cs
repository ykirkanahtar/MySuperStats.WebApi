using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddMatchGroupIdToMatchesTableWithIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "match_groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "create_user_id" },
                values: new object[] { new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "2d5ded2b-62af-48e7-b240-f613f4aff970");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "8da30774-c366-4481-ac7b-9bfff744d433");

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_group_id",
                table: "matches",
                column: "match_group_id");

            migrationBuilder.AddForeignKey(
                name: "fk_matches_match_groups_match_group_id",
                table: "matches",
                column: "match_group_id",
                principalTable: "match_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matches_match_groups_match_group_id",
                table: "matches");

            migrationBuilder.DropIndex(
                name: "ix_matches_match_group_id",
                table: "matches");

            migrationBuilder.UpdateData(
                table: "match_groups",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "create_user_id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

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
    }
}
