using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class coordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defects_Coordinates_CoordinateId",
                table: "Defects");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "DefectAudits");

            migrationBuilder.RenameColumn(
                name: "CoordinateId",
                table: "Defects",
                newName: "LocalSectionLocalSectoionId");

            migrationBuilder.RenameIndex(
                name: "IX_Defects_CoordinateId",
                table: "Defects",
                newName: "IX_Defects_LocalSectionLocalSectoionId");

            migrationBuilder.AddColumn<int>(
                name: "Kilometer",
                table: "Defects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pkt",
                table: "Defects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Defects_LocalSections_LocalSectionLocalSectoionId",
                table: "Defects",
                column: "LocalSectionLocalSectoionId",
                principalTable: "LocalSections",
                principalColumn: "LocalSectoionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defects_LocalSections_LocalSectionLocalSectoionId",
                table: "Defects");

            migrationBuilder.DropColumn(
                name: "Kilometer",
                table: "Defects");

            migrationBuilder.DropColumn(
                name: "Pkt",
                table: "Defects");

            migrationBuilder.RenameColumn(
                name: "LocalSectionLocalSectoionId",
                table: "Defects",
                newName: "CoordinateId");

            migrationBuilder.RenameIndex(
                name: "IX_Defects_LocalSectionLocalSectoionId",
                table: "Defects",
                newName: "IX_Defects_CoordinateId");

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    LocalSectionLocalSectoionId = table.Column<int>(type: "int", nullable: true),
                    Pkt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_LocalSections_LocalSectionLocalSectoionId",
                        column: x => x.LocalSectionLocalSectoionId,
                        principalTable: "LocalSections",
                        principalColumn: "LocalSectoionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefectAudits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfDetection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefectCode = table.Column<int>(type: "int", nullable: false),
                    DefectDepth = table.Column<double>(type: "float", nullable: false),
                    DefectLenght = table.Column<double>(type: "float", nullable: false),
                    Manufacture = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<int>(type: "int", nullable: false),
                    WaySide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectAudits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_LocalSectionLocalSectoionId",
                table: "Coordinates",
                column: "LocalSectionLocalSectoionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Defects_Coordinates_CoordinateId",
                table: "Defects",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
