using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class ReNameStatsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stats");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "954363",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "232007");

            migrationBuilder.CreateTable(
                name: "basketball_stats",
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
                    one_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    two_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    missing_one_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    missing_two_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    rebound = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    steal_ball = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    loose_ball = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    assist = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    interrupt = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_basketball_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_basketball_stats_matches_match_id",
                        column: x => x.match_id,
                        principalTable: "matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_basketball_stats_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_basketball_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_create_user_id",
                table: "basketball_stats",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_player_id",
                table: "basketball_stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_status",
                table: "basketball_stats",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_team_id",
                table: "basketball_stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats",
                columns: new[] { "match_id", "player_id", "team_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basketball_stats");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "232007",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "954363");

            migrationBuilder.CreateTable(
                name: "stats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    assist = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    interrupt = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    loose_ball = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    match_id = table.Column<int>(nullable: false),
                    missing_one_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    missing_two_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    one_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    rebound = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    status = table.Column<int>(nullable: false),
                    steal_ball = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    two_point = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    update_user_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_stats_matches_match_id",
                        column: x => x.match_id,
                        principalTable: "matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stats_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_stats_create_user_id",
                table: "stats",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_player_id",
                table: "stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_status",
                table: "stats",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_stats_team_id",
                table: "stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_match_id_player_id_team_id",
                table: "stats",
                columns: new[] { "match_id", "player_id", "team_id" },
                unique: true);
        }
    }
}
