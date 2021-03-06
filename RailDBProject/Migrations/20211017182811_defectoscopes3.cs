using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class defectoscopes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defectoscopes_Organisations_OrganisationId",
                table: "Defectoscopes");

            migrationBuilder.DropColumn(
                name: "SubOrgId",
                table: "Defectoscopes");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Defectoscopes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Defectoscopes_Organisations_OrganisationId",
                table: "Defectoscopes",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defectoscopes_Organisations_OrganisationId",
                table: "Defectoscopes");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Defectoscopes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubOrgId",
                table: "Defectoscopes",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Defectoscopes_Organisations_OrganisationId",
                table: "Defectoscopes",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
