using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class seed9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 13, 6, 3, 512, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 13, 6, 3, 518, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 13, 6, 3, 518, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "AspnetuserId", "Firstname", "Lastname", "Username" },
                values: new object[] { "21a529ea-f6fd-4f35-ae77-afc54aa83fe5", "Johannes", "Lundkvist", "Jossieri" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AspnetuserId",
                value: "c85d4906-25ec-4e8d-9ebd-9f4b74b506f0");

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 13, 6, 3, 518, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 13, 6, 3, 519, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 12, 54, 54, 830, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 12, 54, 54, 837, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 12, 54, 54, 837, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "AspnetuserId", "Firstname", "Lastname", "Username" },
                values: new object[] { null, "Martin", "Timell", "MT" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AspnetuserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 12, 54, 54, 837, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 12, 54, 54, 838, DateTimeKind.Local));
        }
    }
}
