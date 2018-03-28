using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BasketballStats.WebApi.Migrations
{
    public partial class NewInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "claims",
                columns: table => new
                {
                    claim_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    custom_claim = table.Column<int>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claims", x => x.claim_id);
                });

            migrationBuilder.CreateTable(
                name: "client_applications",
                columns: table => new
                {
                    client_application_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    client_application_code = table.Column<string>(maxLength: 6, nullable: false),
                    client_application_name = table.Column<string>(maxLength: 20, nullable: false),
                    client_application_password = table.Column<string>(maxLength: 50, nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_applications", x => x.client_application_id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    player_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    birth_date = table.Column<DateTime>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    status = table.Column<int>(nullable: false),
                    surname = table.Column<string>(maxLength: 25, nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    role_name = table.Column<string>(maxLength: 25, nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    team_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    color = table.Column<string>(maxLength: 25, nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    access_failed_count = table.Column<int>(nullable: false, defaultValue: 0),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    email_confirm_code = table.Column<string>(maxLength: 6, nullable: false, defaultValue: "786129"),
                    email_confirmed = table.Column<bool>(nullable: false),
                    lockout = table.Column<bool>(nullable: false),
                    lockout_end_date_time = table.Column<DateTime>(maxLength: 256, nullable: true),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    user_name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "client_application_utils",
                columns: table => new
                {
                    client_application_util_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    client_application_id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_application_utils", x => x.client_application_util_id);
                    table.ForeignKey(
                        name: "FK_client_application_utils_client_applications_client_application_id",
                        column: x => x.client_application_id,
                        principalTable: "client_applications",
                        principalColumn: "client_application_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    role_claim_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    claim_id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    role_id = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_claims", x => x.role_claim_id);
                    table.ForeignKey(
                        name: "FK_role_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "claim_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_entity_claims",
                columns: table => new
                {
                    role_entity_claim_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    can_create = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    entity = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_entity_claims", x => x.role_entity_claim_id);
                    table.ForeignKey(
                        name: "FK_role_entity_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    match_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    away_team_id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    duration_in_minutes = table.Column<int>(nullable: false),
                    home_team_id = table.Column<int>(nullable: false),
                    match_date = table.Column<DateTime>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    video_link = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matches", x => x.match_id);
                    table.ForeignKey(
                        name: "FK_matches_teams_away_team_id",
                        column: x => x.away_team_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_matches_teams_home_team_id",
                        column: x => x.home_team_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    user_claim_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    claim_id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claims", x => x.user_claim_id);
                    table.ForeignKey(
                        name: "FK_user_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "claim_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_entity_claims",
                columns: table => new
                {
                    user_entity_claim_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    can_create = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    entity = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_entity_claims", x => x.user_entity_claim_id);
                    table.ForeignKey(
                        name: "FK_user_entity_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_role_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    role_id = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.user_role_id);
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_utils",
                columns: table => new
                {
                    user_util_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_utils", x => x.user_util_id);
                    table.ForeignKey(
                        name: "FK_user_utils_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stats",
                columns: table => new
                {
                    stat_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assist = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    interrupt = table.Column<int>(nullable: false),
                    loose_ball = table.Column<int>(nullable: false),
                    match_id = table.Column<int>(nullable: false),
                    missing_one_point = table.Column<int>(nullable: false),
                    missing_two_point = table.Column<int>(nullable: false),
                    one_point = table.Column<int>(nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    rebound = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    steal_ball = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    two_point = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stats", x => x.stat_id);
                    table.ForeignKey(
                        name: "FK_stats_matches_match_id",
                        column: x => x.match_id,
                        principalTable: "matches",
                        principalColumn: "match_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stats_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_application_utils_client_application_id",
                table: "client_application_utils",
                column: "client_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_matches_away_team_id",
                table: "matches",
                column: "away_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_matches_home_team_id",
                table: "matches",
                column: "home_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_claims_claim_id",
                table: "role_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_entity_claims_role_id",
                table: "role_entity_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_stats_player_id",
                table: "stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_stats_team_id",
                table: "stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_stats_match_id_player_id_team_id",
                table: "stats",
                columns: new[] { "match_id", "player_id", "team_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_name",
                table: "teams",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_claim_id",
                table: "user_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_entity_claims_user_id",
                table: "user_entity_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_utils_user_id",
                table: "user_utils",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_application_utils");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "role_entity_claims");

            migrationBuilder.DropTable(
                name: "stats");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_entity_claims");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_utils");

            migrationBuilder.DropTable(
                name: "client_applications");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
