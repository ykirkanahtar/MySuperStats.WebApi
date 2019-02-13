using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddMatchGroupPlayerAndMatchGroupTeamTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_teams_name",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_matches_match_date_order",
                table: "matches");

            migrationBuilder.DropIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "481907",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "954363");

            migrationBuilder.CreateTable(
                name: "match_groups",
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
                    group_name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_match_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "match_group_players",
                columns: table => new
                {
                    match_group_id = table.Column<int>(nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_match_group_players", x => new { x.match_group_id, x.player_id });
                    table.ForeignKey(
                        name: "fk_match_group_players_match_groups_match_group_id",
                        column: x => x.match_group_id,
                        principalTable: "match_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_match_group_players_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "match_group_teams",
                columns: table => new
                {
                    match_group_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_match_group_teams", x => new { x.match_group_id, x.team_id });
                    table.ForeignKey(
                        name: "fk_match_group_teams_match_groups_match_group_id",
                        column: x => x.match_group_id,
                        principalTable: "match_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_match_group_teams_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_teams_name",
                table: "teams",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" });

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats",
                columns: new[] { "match_id", "player_id", "team_id" });

            migrationBuilder.CreateIndex(
                name: "ix_match_group_players_create_user_id",
                table: "match_group_players",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_players_player_id",
                table: "match_group_players",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_players_status",
                table: "match_group_players",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_teams_create_user_id",
                table: "match_group_teams",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_teams_status",
                table: "match_group_teams",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_teams_team_id",
                table: "match_group_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_groups_create_user_id",
                table: "match_groups",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_groups_group_name",
                table: "match_groups",
                column: "group_name");

            migrationBuilder.CreateIndex(
                name: "ix_match_groups_status",
                table: "match_groups",
                column: "status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "match_group_players");

            migrationBuilder.DropTable(
                name: "match_group_teams");

            migrationBuilder.DropTable(
                name: "match_groups");

            migrationBuilder.DropIndex(
                name: "ix_teams_name",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_matches_match_date_order",
                table: "matches");

            migrationBuilder.DropIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "954363",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "481907");

            migrationBuilder.CreateIndex(
                name: "ix_teams_name",
                table: "teams",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_match_id_player_id_team_id",
                table: "basketball_stats",
                columns: new[] { "match_id", "player_id", "team_id" },
                unique: true);
        }
    }
}
