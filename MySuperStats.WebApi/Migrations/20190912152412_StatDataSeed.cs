using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class StatDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "08166285-4926-400b-8ffc-7857e50cf6e2");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "bbca4031-9b4f-4b6f-990a-752af88c7bcc");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "4ce6b4c8-88a4-4c12-b241-16db3cb5ba22");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "7e796633-2380-41b5-a8c3-7deac22e9f23");

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "id", "color", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "name", "status", "update_date_time", "update_user_id" },
                values: new object[,]
                {
                    { 1, "Green", new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Home", 1, null, null },
                    { 2, "White", new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "Away", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "matches",
                columns: new[] { "id", "away_team_id", "away_team_score", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "duration_in_minutes", "home_team_id", "home_team_score", "match_date", "match_group_id", "order", "status", "update_date_time", "update_user_id", "video_link" },
                values: new object[,]
                {
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
                    { 11, 2, 25.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 30, 1, 16.00m, new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, null, null, "https://www.youtube.com/watch?v=uVldmTIKMjo" },
                    { 12, 2, 4.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 30, 1, 9.00m, new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, null, null, "https://www.youtube.com/watch?v=XaKCOZ5sKUE" }
                });

            migrationBuilder.InsertData(
                table: "basketball_stats",
                columns: new[] { "id", "assist", "create_date_time", "create_user_id", "delete_date_time", "delete_user_id", "interrupt", "loose_ball", "match_id", "missing_one_point", "missing_two_point", "one_point", "rebound", "status", "steal_ball", "team_id", "two_point", "update_date_time", "update_user_id", "user_id" },
                values: new object[,]
                {
                    { 8, 3.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 1, 15.00m, 0.00m, 9.00m, 19.00m, 1, 4.00m, 2, 0.00m, null, null, 4 },
                    { 67, 1.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 9, 6.00m, 5.00m, 7.00m, 8.00m, 1, 10.00m, 1, 0.00m, null, null, 5 },
                    { 66, 3.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 9, 11.00m, 3.00m, 8.00m, 17.00m, 1, 3.00m, 1, 0.00m, null, null, 3 },
                    { 65, 1.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 8.00m, 8, 25.00m, 3.00m, 13.00m, 23.00m, 1, 6.00m, 2, 0.00m, null, null, 7 },
                    { 64, 6.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 8, 19.00m, 4.00m, 8.00m, 22.00m, 1, 0.00m, 2, 1.00m, null, null, 3 },
                    { 63, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 8, 24.00m, 0.00m, 14.00m, 27.00m, 1, 2.00m, 2, 0.00m, null, null, 4 },
                    { 62, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 8, 9.00m, 0.00m, 7.00m, 13.00m, 1, 4.00m, 1, 0.00m, null, null, 10 },
                    { 61, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 4.00m, 3.00m, 8, 8.00m, 0.00m, 4.00m, 18.00m, 1, 2.00m, 1, 0.00m, null, null, 6 },
                    { 60, 1.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 8, 19.00m, 0.00m, 15.00m, 15.00m, 1, 3.00m, 1, 0.00m, null, null, 1 },
                    { 59, 2.00m, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 8, 31.00m, 0.00m, 12.00m, 14.00m, 1, 3.00m, 1, 0.00m, null, null, 8 },
                    { 58, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 7, 15.00m, 0.00m, 5.00m, 10.00m, 1, 1.00m, 2, 0.00m, null, null, 9 },
                    { 57, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 7, 16.00m, 3.00m, 19.00m, 34.00m, 1, 6.00m, 2, 0.00m, null, null, 5 },
                    { 56, 0.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 7, 21.00m, 0.00m, 5.00m, 18.00m, 1, 2.00m, 2, 0.00m, null, null, 1 },
                    { 55, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 7, 36.00m, 9.00m, 8.00m, 12.00m, 1, 5.00m, 2, 3.00m, null, null, 7 },
                    { 54, 3.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 7, 10.00m, 2.00m, 8.00m, 12.00m, 1, 1.00m, 1, 0.00m, null, null, 10 },
                    { 53, 1.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 7, 16.00m, 15.00m, 8.00m, 17.00m, 1, 4.00m, 1, 3.00m, null, null, 11 },
                    { 52, 1.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 8.00m, 7, 23.00m, 0.00m, 14.00m, 13.00m, 1, 1.00m, 1, 0.00m, null, null, 8 },
                    { 51, 2.00m, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2.00m, 2.00m, 7, 17.00m, 1.00m, 11.00m, 40.00m, 1, 1.00m, 1, 0.00m, null, null, 4 },
                    { 50, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 6, 10.00m, 0.00m, 4.00m, 9.00m, 1, 2.00m, 2, 0.00m, null, null, 10 },
                    { 49, 1.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 6, 20.00m, 0.00m, 3.00m, 7.00m, 1, 4.00m, 2, 0.00m, null, null, 8 },
                    { 68, 2.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 9, 16.00m, 0.00m, 2.00m, 8.00m, 1, 3.00m, 1, 0.00m, null, null, 8 },
                    { 69, 3.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 9, 10.00m, 0.00m, 6.00m, 3.00m, 1, 3.00m, 1, 0.00m, null, null, 10 },
                    { 70, 4.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 9, 7.00m, 0.00m, 9.00m, 23.00m, 1, 3.00m, 2, 0.00m, null, null, 4 },
                    { 71, 5.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 9, 13.00m, 0.00m, 3.00m, 11.00m, 1, 1.00m, 2, 0.00m, null, null, 9 },
                    { 91, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 12, 5.00m, 0.00m, 1.00m, 6.00m, 1, 0.00m, 2, 0.00m, null, null, 4 },
                    { 90, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 12, 11.00m, 1.00m, 2.00m, 5.00m, 1, 0.00m, 1, 0.00m, null, null, 14 },
                    { 89, 3.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 12, 3.00m, 0.00m, 2.00m, 6.00m, 1, 0.00m, 1, 0.00m, null, null, 15 },
                    { 88, 2.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 12, 2.00m, 4.00m, 3.00m, 7.00m, 1, 0.00m, 1, 1.00m, null, null, 5 },
                    { 87, 3.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 11, 3.00m, 0.00m, 2.00m, 6.00m, 1, 0.00m, 2, 0.00m, null, null, 10 },
                    { 86, 5.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 9.00m, 11, 5.00m, 6.00m, 4.00m, 6.00m, 1, 0.00m, 2, 5.00m, null, null, 13 },
                    { 85, 2.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 11, 6.00m, 1.00m, 7.00m, 11.00m, 1, 0.00m, 2, 1.00m, null, null, 4 },
                    { 84, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 11, 10.00m, 0.00m, 3.00m, 4.00m, 1, 0.00m, 1, 0.00m, null, null, 2 },
                    { 83, 1.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 11, 8.00m, 2.00m, 5.00m, 4.00m, 1, 0.00m, 1, 1.00m, null, null, 3 },
                    { 48, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 6, 9.00m, 9.00m, 5.00m, 17.00m, 1, 8.00m, 2, 1.00m, null, null, 5 },
                    { 82, 5.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 11, 7.00m, 0.00m, 6.00m, 7.00m, 1, 0.00m, 1, 0.00m, null, null, 6 },
                    { 80, 5.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 10, 14.00m, 0.00m, 8.00m, 7.00m, 1, 5.00m, 2, 0.00m, null, null, 6 },
                    { 79, 4.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2.00m, 6.00m, 10, 14.00m, 0.00m, 9.00m, 8.00m, 1, 1.00m, 2, 0.00m, null, null, 9 },
                    { 78, 1.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 10, 10.00m, 0.00m, 15.00m, 19.00m, 1, 2.00m, 2, 1.00m, null, null, 4 },
                    { 77, 1.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 10, 4.00m, 0.00m, 5.00m, 9.00m, 1, 1.00m, 1, 0.00m, null, null, 10 },
                    { 76, 0.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 10, 15.00m, 0.00m, 8.00m, 14.00m, 1, 3.00m, 1, 0.00m, null, null, 8 },
                    { 75, 5.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 10.00m, 10, 11.00m, 4.00m, 6.00m, 9.00m, 1, 2.00m, 1, 0.00m, null, null, 3 },
                    { 74, 3.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 8.00m, 10, 4.00m, 14.00m, 4.00m, 15.00m, 1, 6.00m, 1, 8.00m, null, null, 5 },
                    { 73, 3.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 9.00m, 9, 17.00m, 0.00m, 10.00m, 8.00m, 1, 4.00m, 2, 0.00m, null, null, 1 },
                    { 72, 4.00m, new DateTime(2018, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 9, 7.00m, 0.00m, 3.00m, 9.00m, 1, 1.00m, 2, 0.00m, null, null, 6 },
                    { 81, 5.00m, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 5.00m, 10, 11.00m, 8.00m, 10.00m, 12.00m, 1, 7.00m, 2, 0.00m, null, null, 12 },
                    { 92, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 12, 5.00m, 3.00m, 1.00m, 6.00m, 1, 0.00m, 2, 0.00m, null, null, 13 },
                    { 47, 1.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 6, 15.00m, 1.00m, 7.00m, 14.00m, 1, 6.00m, 2, 0.00m, null, null, 1 },
                    { 45, 0.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 6, 15.00m, 1.00m, 4.00m, 19.00m, 1, 1.00m, 1, 0.00m, null, null, 11 },
                    { 27, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 1.00m, 3, 18.00m, 0.00m, 13.00m, 18.00m, 1, 1.00m, 2, 0.00m, null, null, 5 },
                    { 26, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 3, 14.00m, 0.00m, 5.00m, 8.00m, 1, 1.00m, 1, 0.00m, null, null, 11 },
                    { 25, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 3, 21.00m, 0.00m, 11.00m, 14.00m, 1, 6.00m, 1, 0.00m, null, null, 7 },
                    { 24, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 3, 7.00m, 0.00m, 12.00m, 3.00m, 1, 0.00m, 1, 0.00m, null, null, 3 },
                    { 23, 4.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 3, 22.00m, 0.00m, 13.00m, 23.00m, 1, 2.00m, 1, 0.00m, null, null, 4 },
                    { 22, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 2, 6.00m, 0.00m, 1.00m, 6.00m, 1, 2.00m, 1, 0.00m, null, null, 10 },
                    { 21, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 5.00m, 2, 20.00m, 0.00m, 8.00m, 12.00m, 1, 3.00m, 1, 0.00m, null, null, 3 },
                    { 20, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 1.00m, 2, 18.00m, 0.00m, 14.00m, 13.00m, 1, 5.00m, 1, 0.00m, null, null, 1 },
                    { 19, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 2, 18.00m, 0.00m, 9.00m, 11.00m, 1, 6.00m, 1, 0.00m, null, null, 7 },
                    { 18, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 2, 12.00m, 0.00m, 14.00m, 10.00m, 1, 3.00m, 2, 0.00m, null, null, 8 },
                    { 17, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 12.00m, 2, 8.00m, 0.00m, 8.00m, 10.00m, 1, 2.00m, 2, 0.00m, null, null, 6 },
                    { 16, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 2, 13.00m, 0.00m, 2.00m, 15.00m, 1, 3.00m, 2, 0.00m, null, null, 9 },
                    { 15, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 2, 12.00m, 0.00m, 12.00m, 13.00m, 1, 0.00m, 2, 0.00m, null, null, 4 },
                    { 14, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 1, 11.00m, 0.00m, 20.00m, 11.00m, 1, 2.00m, 1, 0.00m, null, null, 3 },
                    { 13, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 1, 22.00m, 0.00m, 11.00m, 6.00m, 1, 4.00m, 1, 0.00m, null, null, 7 },
                    { 12, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 6.00m, 1, 12.00m, 0.00m, 7.00m, 17.00m, 1, 4.00m, 1, 0.00m, null, null, 5 },
                    { 11, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 1, 11.00m, 0.00m, 5.00m, 10.00m, 1, 2.00m, 2, 0.00m, null, null, 10 },
                    { 10, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 1, 25.00m, 0.00m, 17.00m, 24.00m, 1, 4.00m, 2, 0.00m, null, null, 1 },
                    { 9, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 1, 10.00m, 0.00m, 12.00m, 8.00m, 1, 5.00m, 2, 0.00m, null, null, 9 },
                    { 28, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 3, 15.00m, 0.00m, 10.00m, 15.00m, 1, 0.00m, 2, 0.00m, null, null, 1 },
                    { 29, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 3, 7.00m, 0.00m, 5.00m, 9.00m, 1, 1.00m, 2, 0.00m, null, null, 10 },
                    { 30, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 3, 4.00m, 0.00m, 7.00m, 8.00m, 1, 0.00m, 2, 0.00m, null, null, 3 },
                    { 31, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 0.00m, 3, 1.00m, 0.00m, 1.00m, 0.00m, 1, 0.00m, 1, 0.00m, null, null, 10 },
                    { 44, 4.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 6, 16.00m, 0.00m, 5.00m, 4.00m, 1, 5.00m, 1, 0.00m, null, null, 9 },
                    { 43, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 6.00m, 6, 10.00m, 1.00m, 8.00m, 6.00m, 1, 0.00m, 1, 0.00m, null, null, 3 },
                    { 42, 9.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 8.00m, 6, 5.00m, 0.00m, 4.00m, 9.00m, 1, 1.00m, 1, 0.00m, null, null, 6 },
                    { 41, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 6, 10.00m, 0.00m, 14.00m, 28.00m, 1, 4.00m, 1, 0.00m, null, null, 4 },
                    { 7, 4.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 2.00m, 5, 18.00m, 0.00m, 15.00m, 14.00m, 1, 2.00m, 1, 0.00m, null, null, 1 },
                    { 6, 5.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 5.00m, 5, 16.00m, 4.00m, 11.00m, 13.00m, 1, 5.00m, 1, 0.00m, null, null, 7 },
                    { 5, 16.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 5, 20.00m, 3.00m, 15.00m, 13.00m, 1, 1.00m, 1, 1.00m, null, null, 3 },
                    { 4, 4.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 5.00m, 5, 10.00m, 6.00m, 11.00m, 20.00m, 1, 5.00m, 1, 1.00m, null, null, 5 },
                    { 3, 1.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 8.00m, 5, 20.00m, 6.00m, 7.00m, 21.00m, 1, 4.00m, 2, 4.00m, null, null, 11 },
                    { 46, 2.00m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 1.00m, 6, 21.00m, 6.00m, 7.00m, 20.00m, 1, 4.00m, 2, 1.00m, null, null, 7 },
                    { 2, 6.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 9.00m, 5, 15.00m, 0.00m, 13.00m, 20.00m, 1, 5.00m, 2, 0.00m, null, null, 6 },
                    { 40, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 1.00m, 4, 6.00m, 0.00m, 1.00m, 6.00m, 1, 2.00m, 2, 0.00m, null, null, 10 },
                    { 39, 1.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 4, 10.00m, 0.00m, 8.00m, 8.00m, 1, 2.00m, 2, 0.00m, null, null, 8 },
                    { 38, 3.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 4.00m, 4, 9.00m, 0.00m, 6.00m, 15.00m, 1, 0.00m, 2, 0.00m, null, null, 1 },
                    { 37, 5.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 2.00m, 5.00m, 4, 12.00m, 0.00m, 6.00m, 9.00m, 1, 0.00m, 2, 0.00m, null, null, 3 },
                    { 36, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 4.00m, 4, 21.00m, 0.00m, 11.00m, 7.00m, 1, 6.00m, 2, 0.00m, null, null, 7 },
                    { 35, 2.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 3.00m, 4, 24.00m, 0.00m, 6.00m, 12.00m, 1, 3.00m, 1, 0.00m, null, null, 11 },
                    { 34, 4.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 3.00m, 4, 17.00m, 0.00m, 8.00m, 16.00m, 1, 5.00m, 1, 0.00m, null, null, 5 },
                    { 33, 6.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 7.00m, 4, 8.00m, 0.00m, 6.00m, 7.00m, 1, 3.00m, 1, 0.00m, null, null, 6 },
                    { 32, 0.00m, new DateTime(2018, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 4, 13.00m, 0.00m, 16.00m, 22.00m, 1, 1.00m, 1, 0.00m, null, null, 4 },
                    { 1, 0.00m, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1.00m, 6.00m, 5, 23.00m, 1.00m, 17.00m, 27.00m, 1, 4.00m, 2, 1.00m, null, null, 4 },
                    { 93, 0.00m, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 0.00m, 2.00m, 12, 5.00m, 3.00m, 2.00m, 3.00m, 1, 0.00m, 2, 0.00m, null, null, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "basketball_stats",
                keyColumn: "id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "matches",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "eba3e2f8-98a4-4ec1-9e2f-2513e61fcbb9");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "f6f2dfb5-ef54-4661-a119-da4e534da831");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "213475b2-4c4e-4c2e-96d5-6c2ca99b760a");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4,
                column: "concurrency_stamp",
                value: "c37f6499-3585-40d6-b250-686d073f219e");
        }
    }
}
