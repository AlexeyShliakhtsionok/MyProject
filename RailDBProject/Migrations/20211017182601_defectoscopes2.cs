using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class defectoscopes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastMaintenansProcedure",
                table: "Defectoscopes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMaintenansProcedure",
                table: "Defectoscopes");
        }
    }
}
