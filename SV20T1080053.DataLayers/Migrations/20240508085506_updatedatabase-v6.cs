using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasev6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_MotocycleTypeTypeId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_MotocycleTypeTypeId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "MotocycleTypeTypeId",
                table: "Motorcycles");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TypeId",
                table: "Motorcycles",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_TypeId",
                table: "Motorcycles",
                column: "TypeId",
                principalTable: "MotocycleTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_TypeId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_TypeId",
                table: "Motorcycles");

            migrationBuilder.AddColumn<int>(
                name: "MotocycleTypeTypeId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MotocycleTypeTypeId",
                table: "Motorcycles",
                column: "MotocycleTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_MotocycleTypeTypeId",
                table: "Motorcycles",
                column: "MotocycleTypeTypeId",
                principalTable: "MotocycleTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
