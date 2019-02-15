using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddFootballStatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "581530",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "481907");

            migrationBuilder.CreateTable(
                name: "football_stats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    match_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    own_goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    penalty_score = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    missed_penalty = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    assist = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    save_goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    concede_goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_football_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_football_stats_matches_match_id",
                        column: x => x.match_id,
                        principalTable: "matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_football_stats_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_football_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_create_user_id",
                table: "football_stats",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_player_id",
                table: "football_stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_status",
                table: "football_stats",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_team_id",
                table: "football_stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_match_id_player_id_team_id",
                table: "football_stats",
                columns: new[] { "match_id", "player_id", "team_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "football_stats");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "481907",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "581530");
        }
    }
}
