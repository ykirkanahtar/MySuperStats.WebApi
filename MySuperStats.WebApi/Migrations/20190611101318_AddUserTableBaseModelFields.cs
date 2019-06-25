using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddUserTableBaseModelFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "create_date_time",
                table: "users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "create_user_id",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_date_time",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "delete_user_id",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_date_time",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "update_user_id",
                table: "users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "2a5ce590-0309-42e0-80c0-8badc9d37343");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "42b3fd63-f929-4371-8be5-ce531e165c06");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "create_user_id" },
                values: new object[] { new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_date_time",
                table: "users");

            migrationBuilder.DropColumn(
                name: "create_user_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "delete_date_time",
                table: "users");

            migrationBuilder.DropColumn(
                name: "delete_user_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "update_date_time",
                table: "users");

            migrationBuilder.DropColumn(
                name: "update_user_id",
                table: "users");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "86376900-6837-409b-b669-f7390aef357e");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "11fc3694-4eec-4a44-b1db-882e92f247f6");
        }
    }
}
