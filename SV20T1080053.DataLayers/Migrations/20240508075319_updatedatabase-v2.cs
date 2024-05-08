using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleBrands_MotocycleBrandBrandId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_MotocycleTypeTypeId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_MotocycleBrandBrandId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "MotocycleBrandBrandId",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "MotocycleTypeTypeId",
                table: "Motorcycles",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Motorcycles_MotocycleTypeTypeId",
                table: "Motorcycles",
                newName: "IX_Motorcycles_BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TypeId",
                table: "Motorcycles",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotocycleBrands_BrandId",
                table: "Motorcycles",
                column: "BrandId",
                principalTable: "MotocycleBrands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Motorcycles_MotocycleBrands_BrandId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_TypeId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_TypeId",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Motorcycles",
                newName: "MotocycleTypeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Motorcycles_BrandId",
                table: "Motorcycles",
                newName: "IX_Motorcycles_MotocycleTypeTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Motorcycles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MotocycleBrandBrandId",
                table: "Motorcycles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MotocycleBrandBrandId",
                table: "Motorcycles",
                column: "MotocycleBrandBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_MotocycleBrands_MotocycleBrandBrandId",
                table: "Motorcycles",
                column: "MotocycleBrandBrandId",
                principalTable: "MotocycleBrands",
                principalColumn: "BrandId");

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
