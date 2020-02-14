using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class Seed_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 12, 16, 7, 12, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 12, 16, 7, 12, 429, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 12, 16, 7, 12, 429, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { "16.321", "56.321" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { "16.321", "56.321" });

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 12, 16, 7, 12, 429, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 12, 16, 7, 12, 429, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 10, 12, 36, 45, 622, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 10, 12, 36, 45, 623, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 10, 12, 36, 45, 623, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 10, 12, 36, 45, 623, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 10, 12, 36, 45, 624, DateTimeKind.Local));
        }
    }
}
