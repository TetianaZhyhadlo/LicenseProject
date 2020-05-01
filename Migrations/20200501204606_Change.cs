using Microsoft.EntityFrameworkCore.Migrations;

namespace LicenseProject.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftID",
                table: "DeveloperTeams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoftID",
                table: "DeveloperTeams",
                nullable: false,
                defaultValue: 0);
        }
    }
}
