using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class seed15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Coat",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Coat", "Datetime" },
                values: new object[] { "Vinter", new DateTime(2020, 2, 9, 18, 33, 51, 535, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                columns: new[] { "Coat", "Datetime" },
                values: new object[] { "Vinter", new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Coat",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Coat", "Datetime" },
                values: new object[] { null, new DateTime(2020, 2, 7, 12, 17, 3, 583, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                columns: new[] { "Coat", "Datetime" },
                values: new object[] { null, new DateTime(2020, 2, 7, 12, 17, 3, 584, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 7, 12, 17, 3, 584, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 7, 12, 17, 3, 585, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 7, 12, 17, 3, 585, DateTimeKind.Local));
        }
    }
}
