using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddNewRolesClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 17,
                column: "claim_type",
                value: "CreateTeam");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 18,
                column: "claim_type",
                value: "DeleteTeam");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 19,
                column: "claim_type",
                value: "CreateMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 20,
                column: "claim_type",
                value: "DeleteMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateBasketballStat", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateFootballStat", 2 });

            migrationBuilder.InsertData(
                table: "role_claims",
                columns: new[] { "id", "claim_type", "claim_value", "role_id" },
                values: new object[,]
                {
                    { 30, "UpdateMatch", "true", 3 },
                    { 29, "CreateMatch", "true", 3 },
                    { 28, "CreateFootballStat", "true", 3 },
                    { 27, "CreateBasketballStat", "true", 3 },
                    { 25, "CreateMatchGroupUser", "true", 2 },
                    { 24, "UpdateMatch", "true", 2 },
                    { 23, "CreateMatch", "true", 2 },
                    { 26, "DeleteMatchGroupUser", "true", 2 }
                });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "00958741-c4fe-49a9-88d0-4dd0b3281af0");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "b0fcbb8b-21ee-4c30-b910-0154b507da3f");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "97eb3d23-d1b6-479e-9579-8adb1a5cbbfa");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "7539a5c2-fd47-4c9a-8ecc-b425d2983afe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 17,
                column: "claim_type",
                value: "SelectMatchGroupTeam");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 18,
                column: "claim_type",
                value: "CreateTeam");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 19,
                column: "claim_type",
                value: "DeleteTeam");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 20,
                column: "claim_type",
                value: "CreateMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "DeleteMatchGroupUser", 1 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "SelectMatchGroupUser", 1 });

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
                column: "concurrency_stamp",
                value: "93baaa91-d0ad-4b35-a93d-8fcd404f0203");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "92db40a2-548a-420a-9b96-abf2ca7d668d");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "498fb71b-b77d-444a-843f-f7063e0d0be0");
        }
    }
}
