using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class DeletePlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_basketball_stats_players_player_id",
                table: "basketball_stats");

            migrationBuilder.DropForeignKey(
                name: "fk_football_stats_players_player_id",
                table: "football_stats");

            migrationBuilder.DropForeignKey(
                name: "fk_match_group_users_players_id",
                table: "match_group_users");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropIndex(
                name: "ix_match_group_users_id",
                table: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_football_stats_player_id",
                table: "football_stats");

            migrationBuilder.DropIndex(
                name: "ix_basketball_stats_player_id",
                table: "basketball_stats");

            migrationBuilder.DropColumn(
                name: "player_id",
                table: "football_stats");

            migrationBuilder.DropColumn(
                name: "player_id",
                table: "basketball_stats");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "60ac0922-28fd-455f-a599-7f16465a5e18");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "21e48d32-43bc-4ceb-ab2e-11f3dea0b7d7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "player_id",
                table: "football_stats",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "player_id",
                table: "basketball_stats",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    birth_date = table.Column<DateTime>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    status = table.Column<int>(nullable: false),
                    surname = table.Column<string>(maxLength: 25, nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    update_user_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.id);
                });

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
                name: "ix_football_stats_player_id",
                table: "football_stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_player_id",
                table: "basketball_stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_create_user_id",
                table: "players",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_status",
                table: "players",
                column: "status");

            migrationBuilder.AddForeignKey(
                name: "fk_basketball_stats_players_player_id",
                table: "basketball_stats",
                column: "player_id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_football_stats_players_player_id",
                table: "football_stats",
                column: "player_id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_match_group_users_players_id",
                table: "match_group_users",
                column: "id",
                principalTable: "players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
