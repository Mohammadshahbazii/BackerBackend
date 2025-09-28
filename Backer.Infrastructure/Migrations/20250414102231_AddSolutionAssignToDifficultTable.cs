using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSolutionAssignToDifficultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolutionAssignToDifficult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DifficultId = table.Column<int>(type: "int", nullable: false),
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionAssignToDifficult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionAssignToDifficult_Difficults_DifficultId",
                        column: x => x.DifficultId,
                        principalTable: "Difficults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolutionAssignToDifficult_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionAssignToDifficult_DifficultId_SolutionId",
                table: "SolutionAssignToDifficult",
                columns: new[] { "DifficultId", "SolutionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolutionAssignToDifficult_SolutionId",
                table: "SolutionAssignToDifficult",
                column: "SolutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolutionAssignToDifficult");
        }
    }
}
