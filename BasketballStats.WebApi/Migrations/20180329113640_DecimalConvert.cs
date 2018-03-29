using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BasketballStats.WebApi.Migrations
{
    public partial class DecimalConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "372132",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "369717");

            migrationBuilder.AlterColumn<decimal>(
                name: "two_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "steal_ball",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "rebound",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "one_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "missing_two_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "missing_one_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "loose_ball",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "interrupt",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "assist",
                table: "stats",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "369717",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "372132");

            migrationBuilder.AlterColumn<int>(
                name: "two_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "steal_ball",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "rebound",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "one_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "missing_two_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "missing_one_point",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "loose_ball",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "interrupt",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "assist",
                table: "stats",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
