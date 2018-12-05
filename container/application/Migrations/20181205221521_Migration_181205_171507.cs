using Microsoft.EntityFrameworkCore.Migrations;

namespace application.Migrations
{
    public partial class Migration_181205_171507 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastNames",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastNamesff",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastNames",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastNamesff",
                table: "Users",
                nullable: true);
        }
    }
}
