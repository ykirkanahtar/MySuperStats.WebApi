using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class RemoveRefreeFieldToMatchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refree",
                table: "Matches");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "204a437b-5227-4376-afef-6ed3e6d6a11f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ce26b171-c71c-4eb2-9b7a-fc000e8133cb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5b8f9c0b-7ebc-45ae-a748-52261eba8789");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6307d1cd-9d93-41ce-8205-fee60cf3f72f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Refree",
                table: "Matches",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8109c5a3-c18b-40d3-a26a-e19cde6c96df");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0cf55638-acdc-4297-853c-06e481f0c978");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c717921b-8097-4c7d-a224-106f893aa097");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "98bf9833-3f15-41ce-a9b4-df2fb057da07");
        }
    }
}
