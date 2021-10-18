using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class localSect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "LocalSections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalSections_OrganisationId",
                table: "LocalSections",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalSections_Organisations_OrganisationId",
                table: "LocalSections",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalSections_Organisations_OrganisationId",
                table: "LocalSections");

            migrationBuilder.DropIndex(
                name: "IX_LocalSections_OrganisationId",
                table: "LocalSections");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "LocalSections");
        }
    }
}
