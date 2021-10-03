using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class localsections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocaSectionlName",
                table: "LocalSections",
                newName: "LocalSectionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalSectionName",
                table: "LocalSections",
                newName: "LocaSectionlName");
        }
    }
}
