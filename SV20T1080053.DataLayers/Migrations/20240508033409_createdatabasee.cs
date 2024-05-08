using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class createdatabasee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleType_MotocycleTypeType_ID",
                table: "Motorcycles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotocycleType",
                table: "MotocycleType");

            migrationBuilder.RenameTable(
                name: "MotocycleType",
                newName: "MotocycleTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotocycleTypes",
                table: "MotocycleTypes",
                column: "Type_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_MotocycleTypeType_ID",
                table: "Motorcycles",
                column: "MotocycleTypeType_ID",
                principalTable: "MotocycleTypes",
                principalColumn: "Type_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_MotocycleTypeType_ID",
                table: "Motorcycles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotocycleTypes",
                table: "MotocycleTypes");

            migrationBuilder.RenameTable(
                name: "MotocycleTypes",
                newName: "MotocycleType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotocycleType",
                table: "MotocycleType",
                column: "Type_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotocycleType_MotocycleTypeType_ID",
                table: "Motorcycles",
                column: "MotocycleTypeType_ID",
                principalTable: "MotocycleType",
                principalColumn: "Type_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
