using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AddRefreeFieldToMatchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Refree",
                table: "Matches",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TwoPoint",
                table: "BasketballStats",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refree",
                table: "Matches");

            migrationBuilder.AlterColumn<decimal>(
                name: "TwoPoint",
                table: "BasketballStats",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "aa4d37ef-991f-432e-8c21-12e5e431c4f6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3e9ee7d6-07c8-48ef-8b83-8fc3e9a1c4c2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "173788bd-b426-46fc-8f01-ddbf874e72d0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "bb4d28c5-f6c3-4537-9055-6231f74c2d41");
        }
    }
}
