using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Weathers",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Temperature",
                table: "Weathers",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Weathers",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Weathers",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Animals",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Animals",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Coat",
                table: "Animals",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Animals",
                maxLength: 128,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 42, 54, 120, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 42, 54, 121, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 42, 54, 121, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                columns: new[] { "Datetime", "Temperature" },
                values: new object[] { new DateTime(2020, 2, 9, 18, 42, 54, 121, DateTimeKind.Local), "22" });

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 42, 54, 122, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Temperature",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Coat",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 33, 51, 535, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local));

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
                columns: new[] { "Datetime", "Temperature" },
                values: new object[] { new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 9, 18, 33, 51, 537, DateTimeKind.Local));
        }
    }
}
