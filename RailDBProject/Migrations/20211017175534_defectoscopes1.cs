using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class defectoscopes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Organisations_OrganisationId",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "SubOrgId",
                table: "Operators");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Operators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Organisations_OrganisationId",
                table: "Operators",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Organisations_OrganisationId",
                table: "Operators");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Operators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubOrgId",
                table: "Operators",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Organisations_OrganisationId",
                table: "Operators",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
