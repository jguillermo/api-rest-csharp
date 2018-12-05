using Microsoft.EntityFrameworkCore.Migrations;

namespace application.Migrations
{
    public partial class Migration_181205_170743 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastNamesff",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNamesff",
                table: "Users");
        }
    }
}
