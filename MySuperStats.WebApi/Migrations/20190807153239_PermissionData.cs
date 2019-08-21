using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class PermissionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "role_claims",
                columns: new[] { "id", "claim_type", "claim_value", "role_id" },
                values: new object[,]
                {
                    { 2, "CreateBasketballStat", "true", 1 },
                    { 19, "DeleteTeam", "true", 1 },
                    { 18, "CreateTeam", "true", 1 },
                    { 17, "SelectMatchGroupTeam", "true", 1 },
                    { 16, "DeleteMatchGroupTeam", "true", 1 },
                    { 15, "CreateMatchGroupTeam", "true", 1 },
                    { 14, "SelectMatchGroup", "true", 1 },
                    { 13, "DeleteMatchGroup", "true", 1 },
                    { 12, "UpdateMatchGroup", "true", 1 },
                    { 11, "CreateMatchGroup", "true", 1 },
                    { 10, "DeleteMatch", "true", 1 },
                    { 9, "UpdateMatch", "true", 1 },
                    { 8, "CreateMatch", "true", 1 },
                    { 7, "DeleteFootballStat", "true", 1 },
                    { 6, "UpdateFootballStat", "true", 1 },
                    { 5, "CreateFootballStat", "true", 1 },
                    { 4, "DeleteBasketballStat", "true", 1 },
                    { 3, "UpdateBasketballStat", "true", 1 }
                });

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
                column: "concurrency_stamp",
                value: "ba2e9986-47f8-4de7-8f74-0601c3a5f8f0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "fa6b1c62-3b1b-44bb-8f98-cc7e5720469c");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "7e57106b-0897-4cb7-9dd0-843f7d7cf67e");
        }
    }
}
