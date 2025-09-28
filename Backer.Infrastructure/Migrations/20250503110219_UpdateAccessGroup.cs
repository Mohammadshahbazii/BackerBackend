using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccessGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccessGroups_Title",
                table: "AccessGroups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AccessGroups_Title",
                table: "AccessGroups",
                column: "Title",
                unique: true);
        }
    }
}
