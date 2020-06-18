using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class Addoptionquesionindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionIndex",
                table: "Options",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionIndex",
                table: "Options");
        }
    }
}
