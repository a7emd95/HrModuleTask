using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class interviewExamQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "InterviewExam",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID");

            migrationBuilder.CreateTable(
                name: "InterviewExamQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewExamQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InterviewExamQuestion_InterviewExam_InterviewExamId",
                        column: x => x.InterviewExamId,
                        principalTable: "InterviewExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewExamQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewExamQuestion_InterviewExamId",
                table: "InterviewExamQuestion",
                column: "InterviewExamId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewExamQuestion_QuestionId",
                table: "InterviewExamQuestion",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewExamQuestion");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublicId",
                table: "InterviewExam",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");
        }
    }
}
