using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class QuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionTypeId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuestionType_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_QuestionType_QuestionTypeId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuestionTypeId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionTypeId",
                table: "Question");
        }
    }
}
