using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class seedingDataInQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "ID", "Type" },
                values: new object[] { 1, "MCQ" });

            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "ID", "Type" },
                values: new object[] { 2, "YesOrNo" });

            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "ID", "Type" },
                values: new object[] { 3, "MultiSelected" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
