using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class PlayerReplaceWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "match_group_players");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "football_stats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "basketball_stats",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "match_group_users",
                columns: table => new
                {
                    match_group_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    update_user_id = table.Column<int>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    player_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_match_group_users", x => new { x.match_group_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_match_group_users_match_groups_match_group_id",
                        column: x => x.match_group_id,
                        principalTable: "match_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_match_group_users_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_match_group_users_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "birth_date", "concurrency_stamp", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "email", "email_confirmed", "first_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "status", "surname", "two_factor_enabled", "update_date_time", "update_user_id", "user_name" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(1975, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.unusemre@gmail.com", true, "ALİ", true, null, "Y.UNUSEMRE@GMAIL.COM", "Y.UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "YUNUSLAR", false, null, null, "y.unusemre@gmail.com" },
                    { 3, 0, new DateTime(1975, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y..unusemre@gmail.com", true, "ARBAK", true, null, "Y..UNUSEMRE@GMAIL.COM", "Y..UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "DEMİRDAĞ", false, null, null, "y..unusemre@gmail.com" },
                    { 4, 0, new DateTime(1970, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y...unusemre@gmail.com", true, "FAHRİ", true, null, "Y...UNUSEMRE@GMAIL.COM", "Y...UNUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "SÖYLEMEZGİLLER", false, null, null, "y...unusemre@gmail.com" },
                    { 5, 0, new DateTime(1982, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu.nusemre@gmail.com", true, "MAHMUT", true, null, "YU.NUSEMRE@GMAIL.COM", "YU.NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "BALCİ", false, null, null, "yu.nusemre@gmail.com" },
                    { 6, 0, new DateTime(1971, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu..nusemre@gmail.com", true, "İLKER", true, null, "YU..NUSEMRE@GMAIL.COM", "YU..NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "OYMAN", false, null, null, "yu..nusemre@gmail.com" },
                    { 7, 0, new DateTime(1984, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yu...nusemre@gmail.com", true, "GÜRCAN", true, null, "YU...NUSEMRE@GMAIL.COM", "YU...NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "ATEŞ", false, null, null, "yu...nusemre@gmail.com" },
                    { 8, 0, new DateTime(1988, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun.usemre@gmail.com", true, "CEYHAN", true, null, "YUN.USEMRE@GMAIL.COM", "YUN.USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "GÖNEN", false, null, null, "yun.usemre@gmail.com" },
                    { 9, 0, new DateTime(1970, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun..usemre@gmail.com", true, "AHMET", true, null, "YUN..USEMRE@GMAIL.COM", "YUN..USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "OKÇULAR", false, null, null, "yun..usemre@gmail.com" },
                    { 10, 0, new DateTime(1973, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yun...usemre@gmail.com", true, "MEHMET", true, null, "YUN...USEMRE@GMAIL.COM", "YUN...USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "AYGÜN", false, null, null, "yun...usemre@gmail.com" },
                    { 11, 0, new DateTime(1987, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunu.semre@gmail.com", true, "FIRAT", true, null, "YUNU.SEMRE@GMAIL.COM", "YUNU.SEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "TİMUR", false, null, null, "yunu.semre@gmail.com" },
                    { 12, 0, new DateTime(1992, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunus.emre@gmail.com", true, "GÖKAY", true, null, "YUNUS.EMRE@GMAIL.COM", "YUNUS.EMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "PATAR", false, null, null, "yunus.emre@gmail.com" },
                    { 13, 0, new DateTime(1989, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "yunusemre@gmail.com", true, "ALTUĞ", true, null, "YUNUSE.MRE@GMAIL.COM", "YUNUSE.MRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "DEMİRSEL", false, null, null, "yunuse.mre@gmail.com" },
                    { 14, 0, new DateTime(2000, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.u.nusemre@gmail.com", true, "ÖMER", true, null, "Y.U.NUSEMRE@GMAIL.COM", "Y.U.NUSEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "SEFER", false, null, null, "y.u.nusemre@gmail.com" },
                    { 15, 0, new DateTime(1987, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca40583b-394d-48a0-879e-c11a21da1aeb", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "y.u.n.usemre@gmail.com", true, "CANER", true, null, "Y.U.N.USEMRE@GMAIL.COM", "Y.U.N.USEMRE@GMAIL.COM", "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", null, false, "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW", 1, "PAZAR", false, null, null, "y.u.n.usemre@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_football_stats_user_id",
                table: "football_stats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_basketball_stats_user_id",
                table: "basketball_stats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_create_user_id",
                table: "match_group_users",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_player_id",
                table: "match_group_users",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_status",
                table: "match_group_users",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_match_group_users_user_id",
                table: "match_group_users",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_basketball_stats_users_user_id",
                table: "basketball_stats",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_football_stats_users_user_id",
                table: "football_stats",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_basketball_stats_users_user_id",
                table: "basketball_stats");

            migrationBuilder.DropForeignKey(
                name: "fk_football_stats_users_user_id",
                table: "football_stats");

            migrationBuilder.DropTable(
                name: "match_group_users");

            migrationBuilder.DropIndex(
                name: "ix_football_stats_user_id",
                table: "football_stats");

            migrationBuilder.DropIndex(
                name: "ix_basketball_stats_user_id",
                table: "basketball_stats");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "football_stats");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "basketball_stats");

            migrationBuilder.CreateTable(
                name: "match_group_players",
                columns: table => new
                {
                    match_group_id = table.Column<int>(nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    create_user_id = table.Column<int>(nullable: false),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    delete_user_id = table.Column<int>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    update_user_id = table.Column<int>(nullable: true)
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

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "2a5ce590-0309-42e0-80c0-8badc9d37343");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "42b3fd63-f929-4371-8be5-ce531e165c06");

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
        }
    }
}
