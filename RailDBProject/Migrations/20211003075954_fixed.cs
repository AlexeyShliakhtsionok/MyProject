using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GlobaSectionName",
                table: "GlobalSections",
                newName: "GlobalSectionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GlobalSectionName",
                table: "GlobalSections",
                newName: "GlobaSectionName");
        }
    }
}
