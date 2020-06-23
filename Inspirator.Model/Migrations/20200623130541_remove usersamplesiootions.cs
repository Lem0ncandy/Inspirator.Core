using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class removeusersamplesiootions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyOptions_Options_OptionId",
                table: "UserSurveyOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyOptions_Samples_SampleId",
                table: "UserSurveyOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSurveyOptions",
                table: "UserSurveyOptions");

            migrationBuilder.RenameTable(
                name: "UserSurveyOptions",
                newName: "SampleOption");

            migrationBuilder.RenameIndex(
                name: "IX_UserSurveyOptions_SampleId",
                table: "SampleOption",
                newName: "IX_SampleOption_SampleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSurveyOptions_OptionId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "UserSurveyOptions");

            migrationBuilder.RenameIndex(
                name: "IX_SampleOption_SampleId",
                table: "UserSurveyOptions",
                newName: "IX_UserSurveyOptions_SampleId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleOption_OptionId",
                table: "UserSurveyOptions",
                newName: "IX_UserSurveyOptions_OptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSurveyOptions",
                table: "UserSurveyOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyOptions_Options_OptionId",
                table: "UserSurveyOptions",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyOptions_Samples_SampleId",
                table: "UserSurveyOptions",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
