using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspirator.Model.Migrations
{
    public partial class quesionchangenametosubject1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuestionId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Subject");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SurveyId",
                table: "Subject",
                newName: "IX_Subject_SurveyId");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Options",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Options_SubjectId",
                table: "Options",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Subject_SubjectId",
                table: "Options",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Surveys_SurveyId",
                table: "Subject",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Subject_SubjectId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Surveys_SurveyId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Options_SubjectId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_SurveyId",
                table: "Questions",
                newName: "IX_Questions_SurveyId");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Options",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
