using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddMatchGroupTypeFieldToMatchGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchGroupType",
                table: "MatchGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MatchGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchGroupType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ce62d35d-8cef-46c5-b29c-53569f64c2b5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ec7bd56f-df19-4d19-a12a-c579771d6b26");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7bf0ba3d-f345-425a-b95a-2ec1ae1a4361");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "11127e40-e982-42f5-a8f7-cf8ffbd6c56d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "0fef55a0-7367-4ebb-a7db-dfdc763580e2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchGroupType",
                table: "MatchGroups");

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
        }
    }
}
