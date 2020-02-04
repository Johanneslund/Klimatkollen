using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class seed12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpeciesId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Speciesname",
                table: "Species",
                newName: "Speciename");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Species",
                newName: "SpecieId");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Animals",
                newName: "SpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                newName: "IX_Animals_SpecieId");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 16, 31, 50, 250, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 16, 31, 50, 257, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 16, 31, 50, 257, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 16, 31, 50, 258, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 16, 31, 50, 258, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "SpecieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Speciename",
                table: "Species",
                newName: "Speciesname");

            migrationBuilder.RenameColumn(
                name: "SpecieId",
                table: "Species",
                newName: "SpeciesId");

            migrationBuilder.RenameColumn(
                name: "SpecieId",
                table: "Animals",
                newName: "SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_SpecieId",
                table: "Animals",
                newName: "IX_Animals_SpeciesId");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 21, 34, 28, 41, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 21, 34, 28, 42, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 21, 34, 28, 42, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 21, 34, 28, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Weathers",
                keyColumn: "WeatherId",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2020, 2, 3, 21, 34, 28, 43, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpeciesId",
                table: "Animals",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
