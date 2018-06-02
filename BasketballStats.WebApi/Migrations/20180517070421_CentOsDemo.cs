using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballStats.WebApi.Migrations
{
    public partial class CentOsDemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "417587",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "334059");

            migrationBuilder.AlterColumn<string>(
                name: "entity",
                table: "user_entity_claims",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "entity",
                table: "role_entity_claims",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "custom_claim",
                table: "claims",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 17, 10, 4, 20, 384, DateTimeKind.Local), "Zj3PdNOPXxNgsPED4keqzw==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "S1YfJ07i3tXLjztorIB4wc7PbYTfnzvtHM98xfTkjQ8=", new DateTime(2018, 5, 17, 10, 4, 20, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 16,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 17,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 18,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 19,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 386, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 385, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 385, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 385, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 385, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 17, 10, 4, 20, 385, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 17, 10, 4, 20, 383, DateTimeKind.Local), "hmU9tdf3H6zaZ70928aiwg==" });

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 17, 10, 4, 20, 383, DateTimeKind.Local), "yUcIMT4JFQk3JYrswN+ALg==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 17, 10, 4, 20, 382, DateTimeKind.Local), "sRi7uIp1NlJjqjsVRI6RSkVe5at1XfZXgYChJtIg0zE=" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 17, 10, 4, 20, 383, DateTimeKind.Local), "J7KYygADn8Q7prjoZ7aIqzJCth2vXcDhGVotHL/1QzI=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "334059",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "417587");

            migrationBuilder.AlterColumn<string>(
                name: "entity",
                table: "user_entity_claims",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "entity",
                table: "role_entity_claims",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "custom_claim",
                table: "claims",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 4, 16, 15, 38, 30, 771, DateTimeKind.Local), "nFOhCb4zVdFj8N/aJxnIVA==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "BAUv/+/r9W/gfMgmjZQFeEL3QiGCTYM3AvIoveonrUs=", new DateTime(2018, 4, 16, 15, 38, 30, 771, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 16,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 17,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 18,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 19,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 773, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 4, 16, 15, 38, 30, 772, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 4, 16, 15, 38, 30, 770, DateTimeKind.Local), "UH62V+fbevgpBSQzNOtoLA==" });

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 4, 16, 15, 38, 30, 770, DateTimeKind.Local), "Is8iS9UHIgQ29B8nu2Wb9g==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 4, 16, 15, 38, 30, 769, DateTimeKind.Local), "DYjQnjF2Pz4BXZDXEr+1VI//xpI0BFsGirov076N44U=" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 4, 16, 15, 38, 30, 770, DateTimeKind.Local), "BDSp9wljhWPHhwsZdvAvUtkMzsdNz69QpOxhLpjSCdU=" });
        }
    }
}
