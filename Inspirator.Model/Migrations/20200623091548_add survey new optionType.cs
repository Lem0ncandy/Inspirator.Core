using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class addsurveynewoptionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionType",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionType",
                table: "Surveys");
        }
    }
}
