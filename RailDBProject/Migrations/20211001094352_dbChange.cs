using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class dbChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "GlobalSections");

            migrationBuilder.DropColumn(
                name: "SubOrgId",
                table: "GlobalSections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "GlobalSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubOrgId",
                table: "GlobalSections",
                type: "int",
                nullable: true);
        }
    }
}
