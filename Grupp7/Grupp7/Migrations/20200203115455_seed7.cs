using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class seed7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 18, 41, 3, 526, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 18, 41, 3, 527, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 18, 41, 3, 527, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 18, 41, 3, 528, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 18, 41, 3, 528, DateTimeKind.Local));
        }
    }
}
