using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class DeletePlayerIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_match_group_users_players_player_id",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_match_group_users_player_id",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_football_stats_match_id_player_id_team_id",
                table: "football_stats");

            migrationBuilder.DropIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats");

            migrationBuilder.DropColumn(
                name: "player_id",
                table: "match_group_users");

            migrationBuilder.AlterColumn<int>(
                name: "player_id",
                table: "football_stats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "basketball_stats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "player_id",
                table: "basketball_stats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "9e2edbc3-fc63-46b9-9c38-3bb886351f68");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "10195ba2-2ca6-49e2-86a8-770e5c89e969");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_id",
                table: "match_group_users",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_match_id_user_id_team_id",
                table: "football_stats",
                columns: new[] { "match_id", "user_id", "team_id" });

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_match_id_user_id_team_id",
                table: "basketball_stats",
                columns: new[] { "match_id", "user_id", "team_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_match_group_users_players_id",
                table: "match_group_users",
                column: "id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_match_group_users_players_id",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_match_group_users_id",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_football_stats_match_id_user_id_team_id",
                table: "football_stats");

            migrationBuilder.DropIndex(
                name: "ix_basketball_stats_match_id_user_id_team_id",
                table: "basketball_stats");

            migrationBuilder.AddColumn<int>(
                name: "player_id",
                table: "match_group_users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "player_id",
                table: "football_stats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "basketball_stats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "player_id",
                table: "basketball_stats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "a6ab7372-f48b-433e-95a6-34383e7e0309");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "634c9ce9-9bac-4f90-891e-37ca84ffeb6f");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_player_id",
                table: "match_group_users",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_match_id_player_id_team_id",
                table: "football_stats",
                columns: new[] { "match_id", "player_id", "team_id" });

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats",
                columns: new[] { "match_id", "player_id", "team_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_match_group_users_players_player_id",
                table: "match_group_users",
                column: "player_id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
