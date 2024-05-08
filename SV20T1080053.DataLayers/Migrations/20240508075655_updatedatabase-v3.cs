using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_MotocycleStatus_MotocycleStatusSatatusId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_MotocycleStatusSatatusId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "MotocycleStatusSatatusId",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_MotocycleStatus_StatusId",
                table: "Invoices",
                column: "StatusId",
                principalTable: "MotocycleStatus",
                principalColumn: "SatatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_MotocycleStatus_StatusId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "MotocycleStatusSatatusId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_MotocycleStatusSatatusId",
                table: "Invoices",
                column: "MotocycleStatusSatatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_MotocycleStatus_MotocycleStatusSatatusId",
                table: "Invoices",
                column: "MotocycleStatusSatatusId",
                principalTable: "MotocycleStatus",
                principalColumn: "SatatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
