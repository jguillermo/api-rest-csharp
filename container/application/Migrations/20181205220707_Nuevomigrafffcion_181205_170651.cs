using Microsoft.EntityFrameworkCore.Migrations;

namespace application.Migrations
{
    public partial class Nuevomigrafffcion_181205_170651 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastNames",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNames",
                table: "Users");
        }
    }
}
