using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class ChangeTeamNameFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "teams",
                newName: "team_name");

            migrationBuilder.RenameIndex(
                name: "ix_teams_name",
                table: "teams",
                newName: "ix_teams_team_name");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "UpdateUser", 1 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "UpdateEmail", 1 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 25,
                column: "claim_type",
                value: "CreateBasketballStat");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 26,
                column: "claim_type",
                value: "CreateFootballStat");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 27,
                column: "claim_type",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 28,
                column: "claim_type",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateMatchGroupUser", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "DeleteMatchGroupUser", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 31,
                column: "claim_type",
                value: "CreateBasketballStat");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 32,
                column: "claim_type",
                value: "CreateFootballStat");

            migrationBuilder.InsertData(
                table: "role_claims",
                columns: new[] { "id", "claim_type", "claim_value", "role_id" },
                values: new object[,]
                {
                    { 33, "CreateMatch", "true", 3 },
                    { 34, "UpdateMatch", "true", 3 }
                });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "048ed3d4-7099-4f81-bcf6-cc9c1de9d92e");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "d8de87fb-dad3-4440-81ae-a54a321ca5fe");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "1dfc1633-98b0-45c9-9557-4c82334bec02");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "2563a28a-716d-4b2c-81b7-2438a1448763");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.RenameColumn(
                name: "team_name",
                table: "teams",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "ix_teams_team_name",
                table: "teams",
                newName: "ix_teams_name");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateBasketballStat", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateFootballStat", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 25,
                column: "claim_type",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 26,
                column: "claim_type",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 27,
                column: "claim_type",
                value: "CreateMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 28,
                column: "claim_type",
                value: "DeleteMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateBasketballStat", 3 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateFootballStat", 3 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 31,
                column: "claim_type",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 32,
                column: "claim_type",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "c8e7495f-e5bb-4067-b580-1aa274bef81e");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "2017fef0-7901-4e64-8482-94c1b090d106");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "e40533f2-acbd-48ec-b209-dbec4754930b");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "023b5948-3db6-4f0e-b38b-ee1eb3117213");
        }
    }
}
