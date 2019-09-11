using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class MatchGroupUserKeyFixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "match_group_users",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users",
                column: "id");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "1ba4a65b-4efe-4d92-bb67-8bd7a0a61bed");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "226c1a73-136d-474f-9a26-a715c81197b1");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "3a3c82ed-337d-43cc-99b3-bc26897b6f07");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "cadbb47f-dd0b-4e7d-ab51-b17e76381545");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_match_group_id_user_id_role_id",
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id", "role_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_match_group_users_match_group_id_user_id_role_id",
                table: "match_group_users");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "match_group_users",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_match_group_users",
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id", "role_id" });

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
        }
    }
}
