using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class alterCandidateAnswerMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerBodyText",
                table: "CandidateAnswer");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "CandidateAnswer",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "CandidateAnswer");

            migrationBuilder.AddColumn<string>(
                name: "AnswerBodyText",
                table: "CandidateAnswer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
