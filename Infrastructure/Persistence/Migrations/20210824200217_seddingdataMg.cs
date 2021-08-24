using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class seddingdataMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "ID", "Email", "Name" },
                values: new object[] { 1, "ahmed@gmail.com", "ahmed" });

            migrationBuilder.InsertData(
                table: "JobPostion",
                columns: new[] { "ID", "IsActive", "Title" },
                values: new object[] { 1, true, "softwear developer" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "ID", "QuestionBodyText", "QuestionTypeId" },
                values: new object[] { 1, "is C# porgramming language", 2 });

            migrationBuilder.InsertData(
                table: "CandidatePosition",
                columns: new[] { "ID", "CandidateId", "IsActive", "JobPositionId" },
                values: new object[] { 1, 1, true, 1 });

            migrationBuilder.InsertData(
                table: "PositionQuestion",
                columns: new[] { "ID", "JobPositionId", "OuestionId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "QuestionAnswer",
                columns: new[] { "ID", "AnswerBodyText", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Yes", true, 1 },
                    { 2, "No", false, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidatePosition",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PositionQuestion",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionAnswer",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionAnswer",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidate",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobPostion",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
