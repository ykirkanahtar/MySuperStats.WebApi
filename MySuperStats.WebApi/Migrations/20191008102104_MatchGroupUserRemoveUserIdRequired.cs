using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class MatchGroupUserRemoveUserIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MatchGroupUsers_MatchGroupId_UserId_RoleId",
                table: "MatchGroupUsers");

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MatchGroupUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "CreateBasketballStat", 2 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "CreateFootballStat", 2 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 27,
                column: "ClaimType",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 28,
                column: "ClaimType",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 29,
                column: "ClaimType",
                value: "CreateMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 30,
                column: "ClaimType",
                value: "DeleteMatchGroupUser");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "CreateBasketballStat", 3 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "CreateFootballStat", 3 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "ClaimType",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "ClaimType",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "18100387-fd41-4efe-9f54-aeec99c6e15c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "47ac4dbc-8309-4cc8-8870-4c069955cb0b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7ea1fd63-c7a7-4fdd-9244-b43cb1cb523a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "cd9df6ce-a5c4-4138-b0fe-f7a032ea81d6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "83e330fd-1a9c-4ac5-9be8-08954884cf65");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_MatchGroupId_PlayerId_RoleId",
                table: "MatchGroupUsers",
                columns: new[] { "MatchGroupId", "PlayerId", "RoleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MatchGroupUsers_MatchGroupId_PlayerId_RoleId",
                table: "MatchGroupUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MatchGroupUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "CreateGuestPlayer", 1 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "UpdateGuestPlayer", 1 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 27,
                column: "ClaimType",
                value: "CreateBasketballStat");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 28,
                column: "ClaimType",
                value: "CreateFootballStat");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 29,
                column: "ClaimType",
                value: "CreateMatch");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 30,
                column: "ClaimType",
                value: "UpdateMatch");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "CreateMatchGroupUser", 2 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ClaimType", "RoleId" },
                values: new object[] { "DeleteMatchGroupUser", 2 });

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 33,
                column: "ClaimType",
                value: "CreateBasketballStat");

            migrationBuilder.UpdateData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 34,
                column: "ClaimType",
                value: "CreateFootballStat");

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 35, "CreateMatch", "true", 3 },
                    { 36, "UpdateMatch", "true", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1ba72279-c88f-455d-b698-5fba6d321e33");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "25694035-1475-41f7-a524-6e6d342c5990");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "50afaa96-3b33-4647-85ee-f9a534739b43");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "f1de6559-7ad2-44ef-890f-d754962c84fa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "6f6543f6-889d-45e6-a758-275aeba9fc0e");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_MatchGroupId_UserId_RoleId",
                table: "MatchGroupUsers",
                columns: new[] { "MatchGroupId", "UserId", "RoleId" },
                unique: true);
        }
    }
}
