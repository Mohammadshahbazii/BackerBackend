using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccessGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "AccessGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroups_ParentId",
                table: "AccessGroups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroups_AccessGroups_ParentId",
                table: "AccessGroups",
                column: "ParentId",
                principalTable: "AccessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroups_AccessGroups_ParentId",
                table: "AccessGroups");

            migrationBuilder.DropIndex(
                name: "IX_AccessGroups_ParentId",
                table: "AccessGroups");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AccessGroups");
        }
    }
}
