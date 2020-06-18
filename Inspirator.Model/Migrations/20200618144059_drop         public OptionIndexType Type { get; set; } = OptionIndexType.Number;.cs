using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class droppublicOptionIndexTypeTypegetsetOptionIndexTypeNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Options");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Surveys");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
