using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHardwareRepairsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardwareRepairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareRepairs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareRepairs_Title",
                table: "HardwareRepairs",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareRepairs");
        }
    }
}
