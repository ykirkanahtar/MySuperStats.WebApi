using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BasketballStats.WebApi.Migrations
{
    public partial class AzureDBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    custom_claim = table.Column<int>(nullable: false)
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
                    user_name = table.Column<string>(maxLength: 25, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    email_confirmed = table.Column<bool>(nullable: false),
                    email_confirm_code = table.Column<string>(maxLength: 6, nullable: false, defaultValue: "334059"),
                    access_failed_count = table.Column<int>(nullable: false, defaultValue: 0),
                    lockout = table.Column<bool>(nullable: false),
                    lockout_end_date_time = table.Column<DateTime>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
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
                    role_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
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
                    role_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_entity_claims", x => x.id);
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
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
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
                    user_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_entity_claims", x => x.id);
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

            migrationBuilder.InsertData(
                table: "client_applications",
                columns: new[] { "id", "client_application_code", "client_application_name", "client_application_password", "create_date_time", "delete_date_time", "status", "update_date_time" },
                values: new object[] { 1, "web", "web", "BAUv/+/r9W/gfMgmjZQFeEL3QiGCTYM3AvIoveonrUs=", new DateTime(2018, 4, 16, 15, 38, 30, 771, DateTimeKind.Local), null, 1, null });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "create_date_time", "delete_date_time", "description", "role_name", "status", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local), null, "Administration Role", "Administrator", 1, null },
                    { 2, new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local), null, "Default User Role", "NormalUser", 1, null },
                    { 3, new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local), null, "User for data writer like stats", "DataWriter", 1, null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "create_date_time", "delete_date_time", "email", "email_confirm_code", "email_confirmed", "lockout", "lockout_end_date_time", "password", "status", "update_date_time", "user_name" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2018, 4, 16, 15, 38, 30, 769, DateTimeKind.Local), null, "admin@admin.org", "9988", false, false, null, "DYjQnjF2Pz4BXZDXEr+1VI//xpI0BFsGirov076N44U=", 1, null, "admin" },
                    { 2, 0, new DateTime(2018, 4, 16, 15, 38, 30, 770, DateTimeKind.Local), null, "fahri@soylemezgiller.net", "8899", false, false, null, "BDSp9wljhWPHhwsZdvAvUtkMzsdNz69QpOxhLpjSCdU=", 1, null, "fahri.soylemezgiller" }
                });

            migrationBuilder.InsertData(
                table: "client_application_utils",
                columns: new[] { "id", "client_application_id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time" },
                values: new object[] { 1, 1, new DateTime(2018, 4, 16, 15, 38, 30, 771, DateTimeKind.Local), null, "nFOhCb4zVdFj8N/aJxnIVA==", 1, null });

            migrationBuilder.InsertData(
                table: "role_entity_claims",
                columns: new[] { "id", "can_create", "can_delete", "can_select", "can_update", "create_date_time", "delete_date_time", "entity", "role_id", "status", "update_date_time" },
                values: new object[,]
                {
                    { 19, true, false, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Stat", 3, 1, null },
                    { 18, true, false, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Player", 3, 1, null },
                    { 17, true, false, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Team", 3, 1, null },
                    { 16, true, false, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Match", 3, 1, null },
                    { 15, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Team", 1, 1, null },
                    { 14, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Stat", 1, 1, null },
                    { 13, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Player", 1, 1, null },
                    { 12, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Match", 1, 1, null },
                    { 10, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "RoleEntityClaim", 1, 1, null },
                    { 11, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Role", 1, 1, null },
                    { 8, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "User", 1, 1, null },
                    { 7, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "UserUtil", 1, 1, null },
                    { 6, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "UserRole", 1, 1, null },
                    { 5, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "UserEntityClaim", 1, 1, null },
                    { 4, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "UserClaim", 1, 1, null },
                    { 3, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "ClientApplication", 1, 1, null },
                    { 2, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "ClientApplicationUtil", 1, 1, null },
                    { 1, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "Claim", 1, 1, null },
                    { 9, true, true, true, true, new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local), null, "RoleClaim", 1, 1, null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "id", "create_date_time", "delete_date_time", "role_id", "status", "update_date_time", "user_id" },
                values: new object[,]
                {
                    { 2, new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local), null, 3, 1, null, 2 },
                    { 1, new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local), null, 1, 1, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "user_utils",
                columns: new[] { "id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 4, 16, 15, 38, 30, 770, DateTimeKind.Local), null, "UH62V+fbevgpBSQzNOtoLA==", 1, null, 1 },
                    { 2, new DateTime(2018, 4, 16, 15, 38, 30, 770, DateTimeKind.Local), null, "Is8iS9UHIgQ29B8nu2Wb9g==", 1, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_client_application_id",
                table: "client_application_utils",
                column: "client_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_matches_away_team_id",
                table: "matches",
                column: "away_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_home_team_id",
                table: "matches",
                column: "home_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_claim_id",
                table: "role_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id",
                table: "role_entity_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_player_id",
                table: "stats",
                column: "player_id");

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
                name: "ix_teams_name",
                table: "teams",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_claim_id",
                table: "user_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id",
                table: "user_entity_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_utils_user_id",
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
