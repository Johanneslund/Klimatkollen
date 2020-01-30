using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Temperature",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PH",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Humidity",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Carbon",
                table: "Weathers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 1, 29, 10, 56, 4, 637, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 1, 29, 10, 56, 4, 638, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "WeatherId", "Carbon", "Datetime", "Humidity", "Latitude", "Longitude", "PH", "Temperature", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 1, 29, 10, 56, 4, 639, DateTimeKind.Local), "87,2", "14.662298", "63.247231", null, null, "Regn", 2 },
                    { 2, "10 mg", new DateTime(2020, 1, 29, 10, 56, 4, 639, DateTimeKind.Local), "87,2", "14.662298", "63.247231", null, "16", "Storsjön, badhusparken", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Temperature",
                table: "Weathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PH",
                table: "Weathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "Weathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "Weathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Humidity",
                table: "Weathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carbon",
                table: "Weathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 1, 29, 10, 48, 17, 343, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 1, 29, 10, 48, 17, 345, DateTimeKind.Local));
        }
    }
}
