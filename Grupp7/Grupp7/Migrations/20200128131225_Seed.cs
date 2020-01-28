using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupp7.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Firstname", "Lastname", "Password", "Phone", "Username" },
                values: new object[] { 1, "Marreparre@live.se", "Martin", "Timell", "lllll", "07228321", "Bajsmannen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Firstname", "Lastname", "Password", "Phone", "Username" },
                values: new object[] { 2, "Marreparre12@live.se", "Björn", "Bajs", "2222", "07228333", "Bajsmannen12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
