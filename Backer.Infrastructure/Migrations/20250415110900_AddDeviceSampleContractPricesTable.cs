using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceSampleContractPricesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceContractSamplePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceContractSampleId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceContractSamplePrices", x => x.Id);
                    table.CheckConstraint("CK_DeviceContractSamplePrices_ValidDateRange", "EndDate >= BeginDate");
                    table.ForeignKey(
                        name: "FK_DeviceContractSamplePrices_DeviceContractSamples_DeviceContractSampleId",
                        column: x => x.DeviceContractSampleId,
                        principalTable: "DeviceContractSamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceContractSamplePrices_DeviceContractSampleId",
                table: "DeviceContractSamplePrices",
                column: "DeviceContractSampleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceContractSamplePrices");
        }
    }
}
