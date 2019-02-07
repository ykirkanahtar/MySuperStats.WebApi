using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class EditMatchTableAddScoresFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "232007",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "577920");

            migrationBuilder.AddColumn<decimal>(
                name: "away_team_score",
                table: "matches",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "home_team_score",
                table: "matches",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "away_team_score",
                table: "matches");

            migrationBuilder.DropColumn(
                name: "home_team_score",
                table: "matches");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "577920",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "232007");
        }
    }
}
