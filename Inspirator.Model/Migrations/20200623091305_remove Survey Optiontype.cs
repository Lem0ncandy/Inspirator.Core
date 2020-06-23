using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class removeSurveyOptiontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Surveys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
