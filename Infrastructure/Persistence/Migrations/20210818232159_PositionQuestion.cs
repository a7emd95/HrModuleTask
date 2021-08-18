using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class PositionQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    QuestionBodyText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PositionQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OuestionId = table.Column<int>(type: "int", nullable: false),
                    JobPositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PositionQuestion_JobPostion_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPostion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionQuestion_Question_OuestionId",
                        column: x => x.OuestionId,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionQuestion_JobPositionId",
                table: "PositionQuestion",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionQuestion_OuestionId",
                table: "PositionQuestion",
                column: "OuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionQuestion");

            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
