﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    ClientApplicationName = table.Column<string>(maxLength: 20, nullable: false),
                    ClientApplicationCode = table.Column<string>(maxLength: 6, nullable: false),
                    ClientApplicationPassword = table.Column<string>(maxLength: 50, nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false),
                    MatchGroupType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    TeamName = table.Column<string>(maxLength: 25, nullable: false),
                    Color = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 1000, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 1000, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 1000, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    LastTokenDate = table.Column<DateTime>(nullable: false),
                    LastLogOutDate = table.Column<DateTime>(nullable: false),
                    TempFirstName = table.Column<string>(nullable: true),
                    TempLastName = table.Column<string>(nullable: true),
                    TempBirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 100, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    MatchGroupId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    DurationInMinutes = table.Column<int>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    HomeTeamScore = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AwayTeamScore = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    VideoLink = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_MatchGroups_MatchGroupId",
                        column: x => x.MatchGroupId,
                        principalTable: "MatchGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchGroupTeams",
                columns: table => new
                {
                    MatchGroupId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchGroupTeams", x => new { x.MatchGroupId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MatchGroupTeams_MatchGroups_MatchGroupId",
                        column: x => x.MatchGroupId,
                        principalTable: "MatchGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchGroupTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 100, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 100, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 100, nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasketballStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    OnePoint = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TwoPoint = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MissingOnePoint = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MissingTwoPoint = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Rebound = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StealBall = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LooseBall = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Assist = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Interrupt = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketballStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FootballStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OwnGoal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PenaltyScore = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MissedPenalty = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Assist = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SaveGoal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ConcedeGoal = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballStats_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchGroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: true),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DeleteUserId = table.Column<int>(nullable: true),
                    MatchGroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchGroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchGroupUsers_MatchGroups_MatchGroupId",
                        column: x => x.MatchGroupId,
                        principalTable: "MatchGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchGroupUsers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchGroupUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchGroupUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ClientApplications",
                columns: new[] { "Id", "ClientApplicationCode", "ClientApplicationName", "ClientApplicationPassword", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "SecurityStamp", "Status", "UpdateDateTime", "UpdateUserId" },
                values: new object[] { 1, "web", "web", "8ohVCPHTYZ3pYrhIBhLYSyiDkYbiKiA7AcRpvkuIOls=", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "nFOhCb4zVdFj8N/aJxnIVA==", 1, null, null });

            migrationBuilder.InsertData(
                table: "MatchGroups",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "GroupName", "MatchGroupType", "Status", "UpdateDateTime", "UpdateUserId" },
                values: new object[] { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Provus Basketbol", 2, 1, null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { 1, "1422193d-0873-4bab-b6c6-f6e69017e6bb", "Admin", "ADMIN", 1 },
                    { 2, "fc2a1b8f-88cc-463f-957e-3ddf474b0f05", "GroupAdmin", "GROUPADMIN", 1 },
                    { 3, "967073f8-8fd2-40de-a0e0-fac293cf2e6c", "Editor", "EDITOR", 1 },
                    { 4, "cecfdfbe-4009-45fa-afda-f03c6b4247db", "Player", "PLAYER", 1 },
                    { 5, "7a9f8b85-4e4f-4e9c-ab0f-cc0e8effcfd6", "Guest", "GUEST", 1 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Color", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "Status", "TeamName", "UpdateDateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, "Green", new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, "Home", null, null },
                    { 2, "White", new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, "Away", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "Email", "EmailConfirmed", "LastLogOutDate", "LastTokenDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TempBirthDate", "TempFirstName", "TempLastName", "TwoFactorEnabled", "UpdateDateTime", "UpdateUserId", "UserName" },
                values: new object[,]
                {
                    { 13, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNUSE.MRE@GMAIL.COM", "YUNUSE.MRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yunuse.mre@gmail.com" },
                    { 12, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunus.emre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNUS.EMRE@GMAIL.COM", "YUNUS.EMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yunus.emre@gmail.com" },
                    { 11, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunu.semre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNU.SEMRE@GMAIL.COM", "YUNU.SEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yunu.semre@gmail.com" },
                    { 10, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun...usemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUN...USEMRE@GMAIL.COM", "YUN...USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yun...usemre@gmail.com" },
                    { 9, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun..usemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUN..USEMRE@GMAIL.COM", "YUN..USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yun..usemre@gmail.com" },
                    { 8, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun.usemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUN.USEMRE@GMAIL.COM", "YUN.USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yun.usemre@gmail.com" },
                    { 3, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y..unusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y..UNUSEMRE@GMAIL.COM", "Y..UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "y..unusemre@gmail.com" },
                    { 6, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu..nusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YU..NUSEMRE@GMAIL.COM", "YU..NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yu..nusemre@gmail.com" },
                    { 5, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu.nusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YU.NUSEMRE@GMAIL.COM", "YU.NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yu.nusemre@gmail.com" },
                    { 4, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y...unusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y...UNUSEMRE@GMAIL.COM", "Y...UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "y...unusemre@gmail.com" },
                    { 14, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.u.nusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y.U.NUSEMRE@GMAIL.COM", "Y.U.NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "y.u.nusemre@gmail.com" },
                    { 2, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.unusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y.UNUSEMRE@GMAIL.COM", "Y.UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "y.unusemre@gmail.com" },
                    { 1, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YUNUSEMRE@GMAIL.COM", "YUNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yunusemre@gmail.com" },
                    { 7, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu...nusemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "YU...NUSEMRE@GMAIL.COM", "YU...NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "yu...nusemre@gmail.com" },
                    { 15, 0, "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.u.n.usemre@gmail.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, "Y.U.N.USEMRE@GMAIL.COM", "Y.U.N.USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, null, null, null, false, null, null, "y.u.n.usemre@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamId", "AwayTeamScore", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "DurationInMinutes", "HomeTeamId", "HomeTeamScore", "MatchDate", "MatchGroupId", "Order", "Status", "UpdateDateTime", "UpdateUserId", "VideoLink" },
                values: new object[,]
                {
                    { 12, 2, 4.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 30, 1, 9.00m, new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, null, null, "https://www.youtube.com/watch?v=XaKCOZ5sKUE" },
                    { 1, 2, 43.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 38.00m, new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=kE99vlYOB2Q" },
                    { 2, 2, 36.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 32.00m, new DateTime(2018, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=wWCI6UwSglc" },
                    { 3, 2, 35.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 42.00m, new DateTime(2018, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=egESDCEFAYI" },
                    { 4, 2, 32.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 36.00m, new DateTime(2018, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=dVuBax06kpY" },
                    { 5, 2, 47.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 56.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=NTWW2JwpOTE" },
                    { 6, 2, 30.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 35.00m, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=EIbnNsMsxQc" },
                    { 7, 2, 43.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 47.00m, new DateTime(2018, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=3p7Z4LNknB8" },
                    { 8, 2, 37.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 38.00m, new DateTime(2018, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=EVJvdvCDuMs" },
                    { 9, 2, 25.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 45, 1, 23.00m, new DateTime(2018, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=Ueo_InIYTBk" },
                    { 10, 2, 44.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 60, 1, 39.00m, new DateTime(2018, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=lplrXOBu3fs" },
                    { 11, 2, 25.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 30, 1, 16.00m, new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=uVldmTIKMjo" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "FirstName", "LastName", "Status", "UpdateDateTime", "UpdateUserId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Yunus Emre", "Kırkanahtar", 1, null, null, 1 },
                    { 15, new DateTime(1987, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Caner", "Pazar", 1, null, null, 15 },
                    { 3, new DateTime(1975, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Arbak", "Demirdağ", 1, null, null, 3 },
                    { 4, new DateTime(1970, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Fahri", "Söylemezgiller", 1, null, null, 4 },
                    { 5, new DateTime(1982, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Mahmut", "Balci", 1, null, null, 5 },
                    { 6, new DateTime(1971, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "İlker", "Oyman", 1, null, null, 6 },
                    { 7, new DateTime(1984, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Gürcan", "Ateş", 1, null, null, 7 },
                    { 8, new DateTime(1988, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Ceyhan", "Gönen", 1, null, null, 8 },
                    { 9, new DateTime(1970, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Ahmet", "Okçular", 1, null, null, 9 },
                    { 10, new DateTime(1973, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Mehmet", "Aygün", 1, null, null, 10 },
                    { 11, new DateTime(1987, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Fırat", "Timur", 1, null, null, 11 },
                    { 12, new DateTime(1992, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Gökay", "Patar", 1, null, null, 12 },
                    { 13, new DateTime(1989, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Altuğ", "Demirsel", 1, null, null, 13 },
                    { 2, new DateTime(1975, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Ali", "Yunuslar", 1, null, null, 2 },
                    { 14, new DateTime(2000, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Ömer", "Sefer", 1, null, null, 14 }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 32, "CreateFootballStat", "true", 3 },
                    { 34, "UpdateMatch", "true", 3 },
                    { 33, "CreateMatch", "true", 3 },
                    { 31, "CreateBasketballStat", "true", 3 },
                    { 29, "CreateMatchGroupUser", "true", 2 },
                    { 2, "CreateBasketballStat", "true", 1 },
                    { 3, "UpdateBasketballStat", "true", 1 },
                    { 4, "DeleteBasketballStat", "true", 1 },
                    { 5, "CreateFootballStat", "true", 1 },
                    { 6, "UpdateFootballStat", "true", 1 },
                    { 7, "DeleteFootballStat", "true", 1 },
                    { 8, "CreateMatch", "true", 1 },
                    { 9, "UpdateMatch", "true", 1 },
                    { 10, "DeleteMatch", "true", 1 },
                    { 11, "CreateMatchGroup", "true", 1 },
                    { 12, "UpdateMatchGroup", "true", 1 },
                    { 13, "DeleteMatchGroup", "true", 1 },
                    { 14, "SelectMatchGroup", "true", 1 },
                    { 30, "DeleteMatchGroupUser", "true", 2 },
                    { 1, "OnlySystemAdmin", "true", 1 },
                    { 16, "DeleteMatchGroupTeam", "true", 1 },
                    { 17, "CreateTeam", "true", 1 },
                    { 18, "DeleteTeam", "true", 1 },
                    { 19, "CreateMatchGroupUser", "true", 1 },
                    { 20, "DeleteMatchGroupUser", "true", 1 },
                    { 21, "AddUserToRole", "true", 1 },
                    { 22, "RemoveUserFromRole", "true", 1 },
                    { 23, "UpdateUser", "true", 1 },
                    { 24, "UpdateEmail", "true", 1 },
                    { 25, "CreateBasketballStat", "true", 2 },
                    { 26, "CreateFootballStat", "true", 2 },
                    { 27, "CreateMatch", "true", 2 },
                    { 28, "UpdateMatch", "true", 2 },
                    { 15, "CreateMatchGroupTeam", "true", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BasketballStats",
                columns: new[] { "Id", "Assist", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "Interrupt", "LooseBall", "MatchId", "MissingOnePoint", "MissingTwoPoint", "OnePoint", "PlayerId", "Rebound", "Status", "StealBall", "TeamId", "TwoPoint", "UpdateDateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 7, 4.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 5, 18.00m, 0.00m, 15.00m, 1, 14.00m, 1, 2.00m, 1, 0.00m, null, null },
                    { 16, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 2, 13.00m, 0.00m, 2.00m, 9, 15.00m, 1, 3.00m, 2, 0.00m, null, null },
                    { 9, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 1, 10.00m, 0.00m, 12.00m, 9, 8.00m, 1, 5.00m, 2, 0.00m, null, null },
                    { 76, 0.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 10, 15.00m, 0.00m, 8.00m, 8, 14.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 68, 2.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 9, 16.00m, 0.00m, 2.00m, 8, 8.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 59, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 8, 31.00m, 0.00m, 12.00m, 8, 14.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 52, 1.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 8.00m, 7, 23.00m, 0.00m, 14.00m, 8, 13.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 49, 1.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 6, 20.00m, 0.00m, 3.00m, 8, 7.00m, 1, 4.00m, 2, 0.00m, null, null },
                    { 39, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 4, 10.00m, 0.00m, 8.00m, 8, 8.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 18, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 2, 12.00m, 0.00m, 14.00m, 8, 10.00m, 1, 3.00m, 2, 0.00m, null, null },
                    { 65, 1.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 8.00m, 8, 25.00m, 3.00m, 13.00m, 7, 23.00m, 1, 6.00m, 2, 0.00m, null, null },
                    { 55, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 7, 36.00m, 9.00m, 8.00m, 7, 12.00m, 1, 5.00m, 2, 3.00m, null, null },
                    { 46, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 1.00m, 6, 21.00m, 6.00m, 7.00m, 7, 20.00m, 1, 4.00m, 2, 1.00m, null, null },
                    { 36, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 4.00m, 4, 21.00m, 0.00m, 11.00m, 7, 7.00m, 1, 6.00m, 2, 0.00m, null, null },
                    { 25, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 3, 21.00m, 0.00m, 11.00m, 7, 14.00m, 1, 6.00m, 1, 0.00m, null, null },
                    { 19, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 2, 18.00m, 0.00m, 9.00m, 7, 11.00m, 1, 6.00m, 1, 0.00m, null, null },
                    { 13, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 1, 22.00m, 0.00m, 11.00m, 7, 6.00m, 1, 4.00m, 1, 0.00m, null, null },
                    { 6, 5.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 5.00m, 5, 16.00m, 4.00m, 11.00m, 7, 13.00m, 1, 5.00m, 1, 0.00m, null, null },
                    { 82, 5.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 11, 7.00m, 0.00m, 6.00m, 6, 7.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 89, 3.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 12, 3.00m, 0.00m, 2.00m, 15, 6.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 72, 4.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 9, 7.00m, 0.00m, 3.00m, 6, 9.00m, 1, 1.00m, 2, 0.00m, null, null },
                    { 61, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 4.00m, 3.00m, 8, 8.00m, 0.00m, 4.00m, 6, 18.00m, 1, 2.00m, 1, 0.00m, null, null },
                    { 44, 4.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 6, 16.00m, 0.00m, 5.00m, 9, 4.00m, 1, 5.00m, 1, 0.00m, null, null },
                    { 42, 9.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 8.00m, 6, 5.00m, 0.00m, 4.00m, 6, 9.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 58, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 7, 15.00m, 0.00m, 5.00m, 9, 10.00m, 1, 1.00m, 2, 0.00m, null, null },
                    { 79, 4.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2.00m, 6.00m, 10, 14.00m, 0.00m, 9.00m, 9, 8.00m, 1, 1.00m, 2, 0.00m, null, null },
                    { 90, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 12, 11.00m, 1.00m, 2.00m, 14, 5.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 92, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 12, 5.00m, 3.00m, 1.00m, 13, 6.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 86, 5.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 9.00m, 11, 5.00m, 6.00m, 4.00m, 13, 6.00m, 1, 0.00m, 2, 5.00m, null, null },
                    { 81, 5.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 10, 11.00m, 8.00m, 10.00m, 12, 12.00m, 1, 7.00m, 2, 0.00m, null, null },
                    { 53, 1.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 7, 16.00m, 15.00m, 8.00m, 11, 17.00m, 1, 4.00m, 1, 3.00m, null, null },
                    { 45, 0.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 6, 15.00m, 1.00m, 4.00m, 11, 19.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 35, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 4, 24.00m, 0.00m, 6.00m, 11, 12.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 26, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 3, 14.00m, 0.00m, 5.00m, 11, 8.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 3, 1.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 8.00m, 5, 20.00m, 6.00m, 7.00m, 11, 21.00m, 1, 4.00m, 2, 4.00m, null, null },
                    { 93, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 12, 5.00m, 3.00m, 2.00m, 10, 3.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 87, 3.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 11, 3.00m, 0.00m, 2.00m, 10, 6.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 77, 1.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 10, 4.00m, 0.00m, 5.00m, 10, 9.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 69, 3.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 9, 10.00m, 0.00m, 6.00m, 10, 3.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 62, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 8, 9.00m, 0.00m, 7.00m, 10, 13.00m, 1, 4.00m, 1, 0.00m, null, null },
                    { 54, 3.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 7, 10.00m, 2.00m, 8.00m, 10, 12.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 50, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 6, 10.00m, 0.00m, 4.00m, 10, 9.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 40, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 4, 6.00m, 0.00m, 1.00m, 10, 6.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 31, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 3, 1.00m, 0.00m, 1.00m, 10, 0.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 29, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 3, 7.00m, 0.00m, 5.00m, 10, 9.00m, 1, 1.00m, 2, 0.00m, null, null },
                    { 22, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 2, 6.00m, 0.00m, 1.00m, 10, 6.00m, 1, 2.00m, 1, 0.00m, null, null },
                    { 11, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 1, 11.00m, 0.00m, 5.00m, 10, 10.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 71, 5.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 9, 13.00m, 0.00m, 3.00m, 9, 11.00m, 1, 1.00m, 2, 0.00m, null, null },
                    { 33, 6.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 4, 8.00m, 0.00m, 6.00m, 6, 7.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 80, 5.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 10, 14.00m, 0.00m, 8.00m, 6, 7.00m, 1, 5.00m, 2, 0.00m, null, null },
                    { 2, 6.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 9.00m, 5, 15.00m, 0.00m, 13.00m, 6, 20.00m, 1, 5.00m, 2, 0.00m, null, null },
                    { 1, 0.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 6.00m, 5, 23.00m, 1.00m, 17.00m, 4, 27.00m, 1, 4.00m, 2, 1.00m, null, null },
                    { 17, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 12.00m, 2, 8.00m, 0.00m, 8.00m, 6, 10.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 75, 5.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 10.00m, 10, 11.00m, 4.00m, 6.00m, 3, 9.00m, 1, 2.00m, 1, 0.00m, null, null },
                    { 66, 3.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 9, 11.00m, 3.00m, 8.00m, 3, 17.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 64, 6.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 8, 19.00m, 4.00m, 8.00m, 3, 22.00m, 1, 0.00m, 2, 1.00m, null, null },
                    { 43, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 6, 10.00m, 1.00m, 8.00m, 3, 6.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 37, 5.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2.00m, 5.00m, 4, 12.00m, 0.00m, 6.00m, 3, 9.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 30, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 3, 4.00m, 0.00m, 7.00m, 3, 8.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 24, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 3, 7.00m, 0.00m, 12.00m, 3, 3.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 21, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 5.00m, 2, 20.00m, 0.00m, 8.00m, 3, 12.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 14, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 1, 11.00m, 0.00m, 20.00m, 3, 11.00m, 1, 2.00m, 1, 0.00m, null, null },
                    { 5, 16.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 5, 20.00m, 3.00m, 15.00m, 3, 13.00m, 1, 1.00m, 1, 1.00m, null, null },
                    { 84, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 11, 10.00m, 0.00m, 3.00m, 2, 4.00m, 1, 0.00m, 1, 0.00m, null, null },
                    { 73, 3.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 9.00m, 9, 17.00m, 0.00m, 10.00m, 1, 8.00m, 1, 4.00m, 2, 0.00m, null, null },
                    { 60, 1.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 8, 19.00m, 0.00m, 15.00m, 1, 15.00m, 1, 3.00m, 1, 0.00m, null, null },
                    { 56, 0.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 7, 21.00m, 0.00m, 5.00m, 1, 18.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 47, 1.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 6, 15.00m, 1.00m, 7.00m, 1, 14.00m, 1, 6.00m, 2, 0.00m, null, null },
                    { 38, 3.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 4, 9.00m, 0.00m, 6.00m, 1, 15.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 28, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 3, 15.00m, 0.00m, 10.00m, 1, 15.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 20, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 1.00m, 2, 18.00m, 0.00m, 14.00m, 1, 13.00m, 1, 5.00m, 1, 0.00m, null, null },
                    { 10, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 1, 25.00m, 0.00m, 17.00m, 1, 24.00m, 1, 4.00m, 2, 0.00m, null, null },
                    { 8, 3.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 1, 15.00m, 0.00m, 9.00m, 4, 19.00m, 1, 4.00m, 2, 0.00m, null, null },
                    { 15, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 2, 12.00m, 0.00m, 12.00m, 4, 13.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 83, 1.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 11, 8.00m, 2.00m, 5.00m, 3, 4.00m, 1, 0.00m, 1, 1.00m, null, null },
                    { 27, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 1.00m, 3, 18.00m, 0.00m, 13.00m, 5, 18.00m, 1, 1.00m, 2, 0.00m, null, null },
                    { 48, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 6, 9.00m, 9.00m, 5.00m, 5, 17.00m, 1, 8.00m, 2, 1.00m, null, null },
                    { 34, 4.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 4, 17.00m, 0.00m, 8.00m, 5, 16.00m, 1, 5.00m, 1, 0.00m, null, null },
                    { 67, 1.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 9, 6.00m, 5.00m, 7.00m, 5, 8.00m, 1, 10.00m, 1, 0.00m, null, null },
                    { 23, 4.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 3, 22.00m, 0.00m, 13.00m, 4, 23.00m, 1, 2.00m, 1, 0.00m, null, null },
                    { 74, 3.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 8.00m, 10, 4.00m, 14.00m, 4.00m, 5, 15.00m, 1, 6.00m, 1, 8.00m, null, null },
                    { 12, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 6.00m, 1, 12.00m, 0.00m, 7.00m, 5, 17.00m, 1, 4.00m, 1, 0.00m, null, null },
                    { 4, 4.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 5.00m, 5, 10.00m, 6.00m, 11.00m, 5, 20.00m, 1, 5.00m, 1, 1.00m, null, null },
                    { 88, 2.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 12, 2.00m, 4.00m, 3.00m, 5, 7.00m, 1, 0.00m, 1, 1.00m, null, null },
                    { 57, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 7, 16.00m, 3.00m, 19.00m, 5, 34.00m, 1, 6.00m, 2, 0.00m, null, null },
                    { 91, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 12, 5.00m, 0.00m, 1.00m, 4, 6.00m, 1, 0.00m, 2, 0.00m, null, null },
                    { 85, 2.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 11, 6.00m, 1.00m, 7.00m, 4, 11.00m, 1, 0.00m, 2, 1.00m, null, null },
                    { 78, 1.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 10, 10.00m, 0.00m, 15.00m, 4, 19.00m, 1, 2.00m, 2, 1.00m, null, null },
                    { 70, 4.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 9, 7.00m, 0.00m, 9.00m, 4, 23.00m, 1, 3.00m, 2, 0.00m, null, null },
                    { 63, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 8, 24.00m, 0.00m, 14.00m, 4, 27.00m, 1, 2.00m, 2, 0.00m, null, null },
                    { 51, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2.00m, 2.00m, 7, 17.00m, 1.00m, 11.00m, 4, 40.00m, 1, 1.00m, 1, 0.00m, null, null },
                    { 41, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 6, 10.00m, 0.00m, 14.00m, 4, 28.00m, 1, 4.00m, 1, 0.00m, null, null },
                    { 32, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 4, 13.00m, 0.00m, 16.00m, 4, 22.00m, 1, 1.00m, 1, 0.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "MatchGroupUsers",
                columns: new[] { "Id", "CreateDateTime", "CreateUserId", "DeleteDateTime", "DeleteUserId", "MatchGroupId", "PlayerId", "RoleId", "Status", "UpdateDateTime", "UpdateUserId", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 5, 2, 1, null, null, 5 },
                    { 12, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 12, 4, 1, null, null, 12 },
                    { 14, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 14, 4, 1, null, null, 14 },
                    { 13, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 13, 4, 1, null, null, 13 },
                    { 11, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 11, 4, 1, null, null, 11 },
                    { 8, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 8, 4, 1, null, null, 8 },
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 1, 1, 1, null, null, 1 },
                    { 10, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 10, 4, 1, null, null, 10 },
                    { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 2, 4, 1, null, null, 2 },
                    { 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4, 2, 1, null, null, 4 },
                    { 7, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 7, 4, 1, null, null, 7 },
                    { 9, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 9, 4, 1, null, null, 9 },
                    { 3, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 3, 4, 1, null, null, 3 },
                    { 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 6, 4, 1, null, null, 6 },
                    { 15, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 15, 4, 1, null, null, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_CreateUserId",
                table: "BasketballStats",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_PlayerId",
                table: "BasketballStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_Status",
                table: "BasketballStats",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_TeamId",
                table: "BasketballStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketballStats_MatchId_PlayerId_TeamId",
                table: "BasketballStats",
                columns: new[] { "MatchId", "PlayerId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_ClientApplicationCode",
                table: "ClientApplications",
                column: "ClientApplicationCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_ClientApplicationName",
                table: "ClientApplications",
                column: "ClientApplicationName");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_Status",
                table: "ClientApplications",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ClientApplications_ClientApplicationCode_ClientApplicationPassword",
                table: "ClientApplications",
                columns: new[] { "ClientApplicationCode", "ClientApplicationPassword" });

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_CreateUserId",
                table: "FootballStats",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_PlayerId",
                table: "FootballStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_Status",
                table: "FootballStats",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_TeamId",
                table: "FootballStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballStats_MatchId_PlayerId_TeamId",
                table: "FootballStats",
                columns: new[] { "MatchId", "PlayerId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CreateUserId",
                table: "Matches",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchGroupId",
                table: "Matches",
                column: "MatchGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Status",
                table: "Matches",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDate_Order",
                table: "Matches",
                columns: new[] { "MatchDate", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroups_CreateUserId",
                table: "MatchGroups",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroups_GroupName",
                table: "MatchGroups",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroups_Status",
                table: "MatchGroups",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupTeams_CreateUserId",
                table: "MatchGroupTeams",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupTeams_Status",
                table: "MatchGroupTeams",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupTeams_TeamId",
                table: "MatchGroupTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_CreateUserId",
                table: "MatchGroupUsers",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_PlayerId",
                table: "MatchGroupUsers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_RoleId",
                table: "MatchGroupUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_Status",
                table: "MatchGroupUsers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_UserId",
                table: "MatchGroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGroupUsers_MatchGroupId_PlayerId_RoleId",
                table: "MatchGroupUsers",
                columns: new[] { "MatchGroupId", "PlayerId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreateUserId",
                table: "Teams",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Status",
                table: "Teams",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamName",
                table: "Teams",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketballStats");

            migrationBuilder.DropTable(
                name: "ClientApplications");

            migrationBuilder.DropTable(
                name: "FootballStats");

            migrationBuilder.DropTable(
                name: "MatchGroupTeams");

            migrationBuilder.DropTable(
                name: "MatchGroupUsers");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "MatchGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}