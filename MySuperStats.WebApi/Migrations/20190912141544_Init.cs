using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_applications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    client_application_name = table.Column<string>(maxLength: 20, nullable: false),
                    client_application_code = table.Column<string>(maxLength: 6, nullable: false),
                    client_application_password = table.Column<string>(maxLength: 50, nullable: false),
                    security_stamp = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "match_groups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 100, nullable: true),
                    concurrency_stamp = table.Column<string>(maxLength: 1000, nullable: true),
                    status = table.Column<int>(nullable: false)
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(maxLength: 100, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 100, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(maxLength: 1000, nullable: true),
                    security_stamp = table.Column<string>(maxLength: 1000, nullable: true),
                    concurrency_stamp = table.Column<string>(maxLength: 1000, nullable: true),
                    phone_number = table.Column<string>(maxLength: 50, nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    surname = table.Column<string>(maxLength: 100, nullable: true),
                    birth_date = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    last_token_date = table.Column<DateTime>(nullable: false),
                    last_log_out_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<int>(nullable: false),
                    claim_type = table.Column<string>(maxLength: 100, nullable: true),
                    claim_value = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
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

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    match_date = table.Column<DateTime>(nullable: false),
                    match_group_id = table.Column<int>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    duration_in_minutes = table.Column<int>(nullable: false),
                    home_team_id = table.Column<int>(nullable: false),
                    away_team_id = table.Column<int>(nullable: false),
                    home_team_score = table.Column<decimal>(nullable: false),
                    away_team_score = table.Column<decimal>(nullable: false),
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
                    table.ForeignKey(
                        name: "fk_matches_match_groups_match_group_id",
                        column: x => x.match_group_id,
                        principalTable: "match_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "match_group_users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    match_group_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_match_group_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_match_group_users_match_groups_match_group_id",
                        column: x => x.match_group_id,
                        principalTable: "match_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_match_group_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_match_group_users_users_user_id",
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    claim_type = table.Column<string>(maxLength: 100, nullable: true),
                    claim_value = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(maxLength: 100, nullable: false),
                    provider_key = table.Column<string>(maxLength: 100, nullable: false),
                    provider_display_name = table.Column<string>(maxLength: 100, nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_logins_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
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
                name: "user_tokens",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    login_provider = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    value = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "basketball_stats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    match_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
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
                        name: "fk_basketball_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_basketball_stats_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "football_stats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    match_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
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
                        name: "fk_football_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_football_stats_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "client_applications",
                columns: new[] { "id", "client_application_code", "client_application_name", "client_application_password", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "security_stamp", "status", "update_date_time", "update_user_id" },
                values: new object[] { 1, "web", "web", "8ohVCPHTYZ3pYrhIBhLYSyiDkYbiKiA7AcRpvkuIOls=", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "nFOhCb4zVdFj8N/aJxnIVA==", 1, null, null });

            migrationBuilder.InsertData(
                table: "match_groups",
                columns: new[] { "id", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "group_name", "status", "update_date_time", "update_user_id" },
                values: new object[] { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Provus Basketbol", 1, null, null });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name", "status" },
                values: new object[,]
                {
                    { 1, "eba3e2f8-98a4-4ec1-9e2f-2513e61fcbb9", "Admin", "ADMIN", 1 },
                    { 2, "f6f2dfb5-ef54-4661-a119-da4e534da831", "GroupAdmin", "GROUPADMIN", 1 },
                    { 3, "213475b2-4c4e-4c2e-96d5-6c2ca99b760a", "Editor", "EDITOR", 1 },
                    { 4, "c37f6499-3585-40d6-b250-686d073f219e", "Player", "PLAYER", 1 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "birth_date", "concurrency_stamp", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "email", "email_confirmed", "first_name", "last_log_out_date", "last_token_date", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "status", "surname", "two_factor_enabled", "update_date_time", "update_user_id", "user_name" },
                values: new object[,]
                {
                    { 13, 0, new DateTime(1989, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunusemre@gmail.com", true, "ALTUĞ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNUSE.MRE@GMAIL.COM", "YUNUSE.MRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "DEMİRSEL", false, null, null, "yunuse.mre@gmail.com" },
                    { 12, 0, new DateTime(1992, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunus.emre@gmail.com", true, "GÖKAY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNUS.EMRE@GMAIL.COM", "YUNUS.EMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "PATAR", false, null, null, "yunus.emre@gmail.com" },
                    { 11, 0, new DateTime(1987, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunu.semre@gmail.com", true, "FIRAT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNU.SEMRE@GMAIL.COM", "YUNU.SEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "TİMUR", false, null, null, "yunu.semre@gmail.com" },
                    { 10, 0, new DateTime(1973, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun...usemre@gmail.com", true, "MEHMET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUN...USEMRE@GMAIL.COM", "YUN...USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "AYGÜN", false, null, null, "yun...usemre@gmail.com" },
                    { 9, 0, new DateTime(1970, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun..usemre@gmail.com", true, "AHMET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUN..USEMRE@GMAIL.COM", "YUN..USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "OKÇULAR", false, null, null, "yun..usemre@gmail.com" },
                    { 8, 0, new DateTime(1988, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun.usemre@gmail.com", true, "CEYHAN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUN.USEMRE@GMAIL.COM", "YUN.USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "GÖNEN", false, null, null, "yun.usemre@gmail.com" },
                    { 5, 0, new DateTime(1982, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu.nusemre@gmail.com", true, "MAHMUT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YU.NUSEMRE@GMAIL.COM", "YU.NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "BALCİ", false, null, null, "yu.nusemre@gmail.com" },
                    { 6, 0, new DateTime(1971, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu..nusemre@gmail.com", true, "İLKER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YU..NUSEMRE@GMAIL.COM", "YU..NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "OYMAN", false, null, null, "yu..nusemre@gmail.com" },
                    { 14, 0, new DateTime(2000, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.u.nusemre@gmail.com", true, "ÖMER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y.U.NUSEMRE@GMAIL.COM", "Y.U.NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "SEFER", false, null, null, "y.u.nusemre@gmail.com" },
                    { 4, 0, new DateTime(1970, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y...unusemre@gmail.com", true, "FAHRİ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y...UNUSEMRE@GMAIL.COM", "Y...UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "SÖYLEMEZGİLLER", false, null, null, "y...unusemre@gmail.com" },
                    { 3, 0, new DateTime(1975, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y..unusemre@gmail.com", true, "ARBAK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y..UNUSEMRE@GMAIL.COM", "Y..UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "DEMİRDAĞ", false, null, null, "y..unusemre@gmail.com" },
                    { 2, 0, new DateTime(1975, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.unusemre@gmail.com", true, "ALİ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y.UNUSEMRE@GMAIL.COM", "Y.UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "YUNUSLAR", false, null, null, "y.unusemre@gmail.com" },
                    { 1, 0, new DateTime(1982, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunusemre@gmail.com", true, "YUNUS EMRE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNUSEMRE@GMAIL.COM", "YUNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "KIRKANAHTAR", false, null, null, "yunusemre@gmail.com" },
                    { 7, 0, new DateTime(1984, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu...nusemre@gmail.com", true, "GÜRCAN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YU...NUSEMRE@GMAIL.COM", "YU...NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "ATEŞ", false, null, null, "yu...nusemre@gmail.com" },
                    { 15, 0, new DateTime(1987, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.u.n.usemre@gmail.com", true, "CANER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y.U.N.USEMRE@GMAIL.COM", "Y.U.N.USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "PAZAR", false, null, null, "y.u.n.usemre@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "match_group_users",
                columns: new[] { "id", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "match_group_id", "role_id", "status", "update_date_time", "update_user_id", "user_id" },
                values: new object[,]
                {
                    { 15, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 15 },
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 1, 1, null, null, 1 },
                    { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 2 },
                    { 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 2, 1, null, null, 4 },
                    { 5, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 2, 1, null, null, 5 },
                    { 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 6 },
                    { 7, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 7 },
                    { 3, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 3 },
                    { 9, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 9 },
                    { 10, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 10 },
                    { 11, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 11 },
                    { 12, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 12 },
                    { 13, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 13 },
                    { 8, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 8 },
                    { 14, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 1, null, null, 14 }
                });

            migrationBuilder.InsertData(
                table: "role_claims",
                columns: new[] { "id", "claim_type", "claim_value", "role_id" },
                values: new object[,]
                {
                    { 25, "CreateMatch", "true", 2 },
                    { 32, "UpdateMatch", "true", 3 },
                    { 31, "CreateMatch", "true", 3 },
                    { 30, "CreateFootballStat", "true", 3 },
                    { 29, "CreateBasketballStat", "true", 3 },
                    { 28, "DeleteMatchGroupUser", "true", 2 },
                    { 27, "CreateMatchGroupUser", "true", 2 },
                    { 26, "UpdateMatch", "true", 2 },
                    { 24, "CreateFootballStat", "true", 2 },
                    { 22, "RemoveUserFromRole", "true", 1 },
                    { 2, "CreateBasketballStat", "true", 1 },
                    { 3, "UpdateBasketballStat", "true", 1 },
                    { 4, "DeleteBasketballStat", "true", 1 },
                    { 5, "CreateFootballStat", "true", 1 },
                    { 6, "UpdateFootballStat", "true", 1 },
                    { 7, "DeleteFootballStat", "true", 1 },
                    { 8, "CreateMatch", "true", 1 },
                    { 9, "UpdateMatch", "true", 1 },
                    { 10, "DeleteMatch", "true", 1 },
                    { 23, "CreateBasketballStat", "true", 2 },
                    { 11, "CreateMatchGroup", "true", 1 },
                    { 13, "DeleteMatchGroup", "true", 1 },
                    { 14, "SelectMatchGroup", "true", 1 },
                    { 15, "CreateMatchGroupTeam", "true", 1 },
                    { 16, "DeleteMatchGroupTeam", "true", 1 },
                    { 17, "CreateTeam", "true", 1 },
                    { 18, "DeleteTeam", "true", 1 },
                    { 19, "CreateMatchGroupUser", "true", 1 },
                    { 20, "DeleteMatchGroupUser", "true", 1 },
                    { 21, "AddUserToRole", "true", 1 },
                    { 12, "UpdateMatchGroup", "true", 1 },
                    { 1, "OnlySystemAdmin", "true", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_create_user_id",
                table: "basketball_stats",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_status",
                table: "basketball_stats",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_team_id",
                table: "basketball_stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_user_id",
                table: "basketball_stats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_match_id_user_id_team_id",
                table: "basketball_stats",
                columns: new[] { "match_id", "user_id", "team_id" });

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
                name: "ix_client_applications_client_application_code_client_applicati~",
                table: "client_applications",
                columns: new[] { "client_application_code", "client_application_password" });

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_create_user_id",
                table: "football_stats",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_status",
                table: "football_stats",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_team_id",
                table: "football_stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_user_id",
                table: "football_stats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_match_id_user_id_team_id",
                table: "football_stats",
                columns: new[] { "match_id", "user_id", "team_id" });

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
                name: "ix_match_group_users_create_user_id",
                table: "match_group_users",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_role_id",
                table: "match_group_users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_status",
                table: "match_group_users",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_user_id",
                table: "match_group_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_match_group_id_user_id_role_id",
                table: "match_group_users",
                columns: new[] { "match_group_id", "user_id", "role_id" },
                unique: true);

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
                name: "ix_matches_match_group_id",
                table: "matches",
                column: "match_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_status",
                table: "matches",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" });

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "role_name_index",
                table: "roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_teams_create_user_id",
                table: "teams",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_name",
                table: "teams",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_teams_status",
                table: "teams",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_logins_user_id",
                table: "user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "email_index",
                table: "users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "user_name_index",
                table: "users",
                column: "normalized_user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basketball_stats");

            migrationBuilder.DropTable(
                name: "client_applications");

            migrationBuilder.DropTable(
                name: "football_stats");

            migrationBuilder.DropTable(
                name: "match_group_teams");

            migrationBuilder.DropTable(
                name: "match_group_users");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "match_groups");
        }
    }
}
