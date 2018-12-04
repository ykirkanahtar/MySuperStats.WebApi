using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BasketballStats.WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applications",
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
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "claims",
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
                    custom_claim = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_applications",
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
                    client_application_name = table.Column<string>(maxLength: 20, nullable: false),
                    client_application_code = table.Column<string>(maxLength: 6, nullable: false),
                    client_application_password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "players",
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
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    surname = table.Column<string>(maxLength: 25, nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
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
                    role_name = table.Column<string>(maxLength: 25, nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
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
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    color = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
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
                    user_name = table.Column<string>(maxLength: 25, nullable: false),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    surname = table.Column<string>(maxLength: 30, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    email_confirmed = table.Column<bool>(nullable: false),
                    email_confirm_code = table.Column<string>(maxLength: 6, nullable: false, defaultValue: "577920"),
                    access_failed_count = table.Column<int>(nullable: false, defaultValue: 0),
                    lockout = table.Column<bool>(nullable: false),
                    lockout_end_date_time = table.Column<DateTime>(maxLength: 256, nullable: true),
                    application_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client_application_utils",
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
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    client_application_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_application_utils", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_application_utils_client_applications_client_applica~",
                        column: x => x.client_application_id,
                        principalTable: "client_applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
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
                    application_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_role_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_entity_claims",
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
                    application_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(maxLength: 50, nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_entity_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_entity_claims_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_role_entity_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matches",
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
                    match_date = table.Column<DateTime>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    duration_in_minutes = table.Column<int>(nullable: false),
                    home_team_id = table.Column<int>(nullable: false),
                    away_team_id = table.Column<int>(nullable: false),
                    video_link = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matches", x => x.id);
                    table.ForeignKey(
                        name: "fk_matches_teams_away_team_id",
                        column: x => x.away_team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_matches_teams_home_team_id",
                        column: x => x.home_team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "application_users",
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
                    user_id = table.Column<int>(nullable: false),
                    application_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_application_users_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_application_users_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
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
                    application_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_entity_claims",
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
                    application_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(maxLength: 50, nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_entity_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_entity_claims_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_entity_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
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
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_utils",
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
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_utils", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_utils_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stats",
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
                name: "ix_application_users_status",
                table: "application_users",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_application_users_application_id_status",
                table: "application_users",
                columns: new[] { "application_id", "status" });

            migrationBuilder.CreateIndex(
                name: "ix_application_users_user_id_status",
                table: "application_users",
                columns: new[] { "user_id", "status" });

            migrationBuilder.CreateIndex(
                name: "ix_applications_name",
                table: "applications",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_applications_status",
                table: "applications",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_claims_custom_claim",
                table: "claims",
                column: "custom_claim");

            migrationBuilder.CreateIndex(
                name: "ix_claims_status",
                table: "claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_client_application_id",
                table: "client_application_utils",
                column: "client_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_status",
                table: "client_application_utils",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_client_applications_client_application_code",
                table: "client_applications",
                column: "client_application_code");

            migrationBuilder.CreateIndex(
                name: "ix_client_applications_client_application_name",
                table: "client_applications",
                column: "client_application_name");

            migrationBuilder.CreateIndex(
                name: "ix_client_applications_status",
                table: "client_applications",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_client_applications_client_application_code_client_applicat~",
                table: "client_applications",
                columns: new[] { "client_application_code", "client_application_password" });

            migrationBuilder.CreateIndex(
                name: "ix_matches_away_team_id",
                table: "matches",
                column: "away_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_create_user_id",
                table: "matches",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_home_team_id",
                table: "matches",
                column: "home_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_status",
                table: "matches",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_players_create_user_id",
                table: "players",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_status",
                table: "players",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_claim_id",
                table: "role_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_status",
                table: "role_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_application_id_role_id_claim_id",
                table: "role_claims",
                columns: new[] { "application_id", "role_id", "claim_id" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id",
                table: "role_entity_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_status",
                table: "role_entity_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_application_id_role_id_entity_can_create",
                table: "role_entity_claims",
                columns: new[] { "application_id", "role_id", "entity", "can_create" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_application_id_role_id_entity_can_delete",
                table: "role_entity_claims",
                columns: new[] { "application_id", "role_id", "entity", "can_delete" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_application_id_role_id_entity_can_select",
                table: "role_entity_claims",
                columns: new[] { "application_id", "role_id", "entity", "can_select" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_application_id_role_id_entity_can_update",
                table: "role_entity_claims",
                columns: new[] { "application_id", "role_id", "entity", "can_update" });

            migrationBuilder.CreateIndex(
                name: "ix_roles_role_name",
                table: "roles",
                column: "role_name");

            migrationBuilder.CreateIndex(
                name: "ix_roles_status",
                table: "roles",
                column: "status");

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

            migrationBuilder.CreateIndex(
                name: "ix_teams_create_user_id",
                table: "teams",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_name",
                table: "teams",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_teams_status",
                table: "teams",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_claim_id",
                table: "user_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_status",
                table: "user_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_application_id_user_id_claim_id",
                table: "user_claims",
                columns: new[] { "application_id", "user_id", "claim_id" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_status",
                table: "user_entity_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id",
                table: "user_entity_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_application_id_user_id_entity_can_create",
                table: "user_entity_claims",
                columns: new[] { "application_id", "user_id", "entity", "can_create" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_application_id_user_id_entity_can_delete",
                table: "user_entity_claims",
                columns: new[] { "application_id", "user_id", "entity", "can_delete" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_application_id_user_id_entity_can_select",
                table: "user_entity_claims",
                columns: new[] { "application_id", "user_id", "entity", "can_select" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_application_id_user_id_entity_can_update",
                table: "user_entity_claims",
                columns: new[] { "application_id", "user_id", "entity", "can_update" });

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_status",
                table: "user_roles",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id_status",
                table: "user_roles",
                columns: new[] { "user_id", "status" });

            migrationBuilder.CreateIndex(
                name: "ix_user_utils_status",
                table: "user_utils",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_utils_user_id",
                table: "user_utils",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_application_id",
                table: "users",
                column: "application_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "ix_users_status",
                table: "users",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_name",
                table: "users",
                column: "user_name");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_name_password",
                table: "users",
                columns: new[] { "user_name", "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_users");

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

            migrationBuilder.DropTable(
                name: "applications");
        }
    }
}
