using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddMatchGroupUsersDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "id", "status", "update_date_time", "update_user_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 1, null, null },
                    { 1, 15, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 15, 1, null, null },
                    { 1, 14, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 14, 1, null, null },
                    { 1, 13, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 13, 1, null, null },
                    { 1, 12, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 12, 1, null, null },
                    { 1, 11, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 11, 1, null, null },
                    { 1, 10, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 10, 1, null, null },
                    { 1, 9, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 9, 1, null, null },
                    { 1, 7, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 7, 1, null, null },
                    { 1, 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 6, 1, null, null },
                    { 1, 5, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 5, 1, null, null },
                    { 1, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 4, 1, null, null },
                    { 1, 3, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 3, 1, null, null },
                    { 1, 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2, 1, null, null },
                    { 1, 8, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 8, 1, null, null }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "match_group_users",
                keyColumns: new[] { "match_group_id", "user_id" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "aa2bf298-b000-418b-b557-4aaa3a5e8125");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "d5a5b364-5843-4d2c-ab8c-58e4665bda11");
        }
    }
}
