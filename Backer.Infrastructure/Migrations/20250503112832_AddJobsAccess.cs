using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJobsAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobsAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessGroupID = table.Column<int>(type: "int", nullable: false),
                    JobTitleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsAccesses_AccessGroups_AccessGroupID",
                        column: x => x.AccessGroupID,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsAccesses_JobTitles_JobTitleID",
                        column: x => x.JobTitleID,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobsAccesses_AccessGroupID",
                table: "JobsAccesses",
                column: "AccessGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_JobsAccesses_JobTitleID",
                table: "JobsAccesses",
                column: "JobTitleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsAccesses");
        }
    }
}
