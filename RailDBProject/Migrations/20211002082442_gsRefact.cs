using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class gsRefact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "GlobalSections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "GlobalSections");
        }
    }
}
