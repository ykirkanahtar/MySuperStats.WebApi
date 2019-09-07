using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddNewRoles190907 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "user_roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "AddUserToRole", 1 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "RemoveUserFromRole", 1 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 23,
                column: "claim_type",
                value: "CreateBasketballStat");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 24,
                column: "claim_type",
                value: "CreateFootballStat");

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
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateMatchGroupUser", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "DeleteMatchGroupUser", 2 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 29,
                column: "claim_type",
                value: "CreateBasketballStat");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 30,
                column: "claim_type",
                value: "CreateFootballStat");

            migrationBuilder.InsertData(
                table: "role_claims",
                columns: new[] { "id", "claim_type", "claim_value", "role_id" },
                values: new object[,]
                {
                    { 31, "CreateMatch", "true", 3 },
                    { 32, "UpdateMatch", "true", 3 }
                });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "b4c53d34-fdec-4008-a08c-3216d9372976");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "3d1fdd49-a8e2-4883-8150-adcf45672359");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "6e0ee792-19a6-49a6-b051-fbcd5ee95612");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "b7e1936a-dbd2-4c68-ad8d-361f50594f01");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DropColumn(
                name: "id",
                table: "user_roles");

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

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 23,
                column: "claim_type",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 24,
                column: "claim_type",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 25,
                column: "claim_type",
                value: "CreateMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 26,
                column: "claim_type",
                value: "DeleteMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateBasketballStat", 3 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "claim_type", "role_id" },
                values: new object[] { "CreateFootballStat", 3 });

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 29,
                column: "claim_type",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "role_claims",
                keyColumn: "id",
                keyValue: 30,
                column: "claim_type",
                value: "UpdateMatch");

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
    }
}
