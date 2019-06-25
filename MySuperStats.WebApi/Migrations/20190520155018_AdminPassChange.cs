using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperStats.WebApi.Migrations
{
    public partial class AdminPassChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "f24c022c-5386-48c1-b9c7-5abd674b182f");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "2cd35c1b-e0ec-4dc1-a5dd-faa82c100dc0");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password_hash", "security_stamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEF8ox4odFYBEgV+2mBcGv8jw4KXJKnjayRE9pJ91NG8Yp+9uSVMx6QU7TP2M9MOCGw==", "ABQONVFKVTNPYSRLSGOFKH5KNSVIANUW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "88b9f1f9-ffe4-4da6-8644-1cce2546597b");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "3e3d7e74-59dd-42e0-9eaa-2639c3242728");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password_hash", "security_stamp" },
                values: new object[] { "AQAAAAEAACcQAAAAENSPXOU9x3TFRm/xL1yZ+nOlmJjfQA6T6Ps9li/IbhygCfnEc21xsWiRjLqznbXIow==", "XJWH4G2SYXTCIOTRVYGJJEWTYPWGEYHB" });
        }
    }
}
