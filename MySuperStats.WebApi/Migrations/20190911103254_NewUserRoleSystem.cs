using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class NewUserRoleSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_roles_user_id_role_id_match_group_id",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users");

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

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "user_id", "role_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DropColumn(
                name: "id",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "match_group_id",
                table: "user_roles");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "match_group_users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id", "role_id" });

            migrationBuilder.InsertData(
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id", "role_id", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "id", "status", "update_date_time", "update_user_id" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 1, null, null },
                    { 1, 15, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 15, 1, null, null },
                    { 1, 14, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 14, 1, null, null },
                    { 1, 13, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 13, 1, null, null },
                    { 1, 12, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 12, 1, null, null },
                    { 1, 11, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 11, 1, null, null },
                    { 1, 9, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 9, 1, null, null },
                    { 1, 10, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 10, 1, null, null },
                    { 1, 7, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 7, 1, null, null },
                    { 1, 6, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 6, 1, null, null },
                    { 1, 5, 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 5, 1, null, null },
                    { 1, 4, 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 4, 1, null, null },
                    { 1, 3, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 3, 1, null, null },
                    { 1, 2, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2, 1, null, null },
                    { 1, 8, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 8, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "2c14f509-a144-494b-85a3-6147a44913fd");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "c61f493f-6451-4658-b844-d7e2533de9bc");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "920a1cf3-1049-4f35-ad30-228ae3a06a77");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "e250af7f-d343-4602-b5ea-d6e43f70e72f");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_role_id",
                table: "match_group_users",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_match_group_users_roles_role_id",
                table: "match_group_users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_match_group_users_roles_role_id",
                table: "match_group_users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_match_group_users_role_id",
                table: "match_group_users");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "match_group_users");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "user_roles",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "match_group_id",
                table: "user_roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id" });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "96636f89-d564-49ab-88e0-f04fb5e27340");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "58fae60b-0f6b-45c4-b2a4-4e7ac5e323cb");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "d02b2d23-c82a-48a7-8f48-23d94c8337c7");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "9f2bf02a-6df4-4125-9303-48ac0949a36b");

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "user_id", "role_id", "id", "match_group_id" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id_role_id_match_group_id",
                table: "user_roles",
                columns: new[] { "user_id", "role_id", "match_group_id" },
                unique: true);
        }
    }
}
