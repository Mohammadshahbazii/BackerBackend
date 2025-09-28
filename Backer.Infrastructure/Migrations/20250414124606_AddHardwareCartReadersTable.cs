using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHardwareCartReadersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardwareCartReaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareCartReaders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareCartReaders_Title",
                table: "HardwareCartReaders",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareCartReaders");
        }
    }
}
