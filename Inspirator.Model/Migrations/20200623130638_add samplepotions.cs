using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class addsamplepotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleOption_Options_OptionId",
                table: "SampleOption");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleOption_Samples_SampleId",
                table: "SampleOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleOption",
                table: "SampleOption");

            migrationBuilder.RenameTable(
                name: "SampleOption",
                newName: "SampleOptions");

            migrationBuilder.RenameIndex(
                name: "IX_SampleOption_SampleId",
                table: "SampleOptions",
                newName: "IX_SampleOptions_SampleId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleOption_OptionId",
                table: "SampleOptions",
                newName: "IX_SampleOptions_OptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleOptions",
                table: "SampleOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleOptions_Options_OptionId",
                table: "SampleOptions",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleOptions_Samples_SampleId",
                table: "SampleOptions",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleOptions_Options_OptionId",
                table: "SampleOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleOptions_Samples_SampleId",
                table: "SampleOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleOptions",
                table: "SampleOptions");

            migrationBuilder.RenameTable(
                name: "SampleOptions",
                newName: "SampleOption");

            migrationBuilder.RenameIndex(
                name: "IX_SampleOptions_SampleId",
                table: "SampleOption",
                newName: "IX_SampleOption_SampleId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleOptions_OptionId",
                table: "SampleOption",
                newName: "IX_SampleOption_OptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleOption",
                table: "SampleOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleOption_Options_OptionId",
                table: "SampleOption",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleOption_Samples_SampleId",
                table: "SampleOption",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
