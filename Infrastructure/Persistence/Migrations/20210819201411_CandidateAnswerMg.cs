using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class CandidateAnswerMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewExamQuestion");

            migrationBuilder.CreateTable(
                name: "CandidateAnswer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AnswerBodyText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    InterviewExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAnswer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateAnswer_InterviewExam_InterviewExamId",
                        column: x => x.InterviewExamId,
                        principalTable: "InterviewExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnswer_InterviewExamId",
                table: "CandidateAnswer",
                column: "InterviewExamId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnswer_QuestionId",
                table: "CandidateAnswer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateAnswer");

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
    }
}
