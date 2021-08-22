using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class alterQuestionTypeMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswersCapcity",
                table: "QuestionType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "ID",
                keyValue: 1,
                column: "AnswersCapcity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "ID",
                keyValue: 2,
                column: "AnswersCapcity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "QuestionType",
                keyColumn: "ID",
                keyValue: 3,
                column: "AnswersCapcity",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswersCapcity",
                table: "QuestionType");
        }
    }
}
