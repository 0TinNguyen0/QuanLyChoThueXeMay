using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class uptadedatabasev7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_MotocycleStatus_StatusId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleBrands_BrandId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_MotocycleTypes_TypeId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "MotocycleBrands");

            migrationBuilder.DropTable(
                name: "MotocycleStatus");

            migrationBuilder.DropTable(
                name: "MotocycleTypes");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_BrandId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_TypeId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Motorcycles",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Motorcycles",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Invoices",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Rentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "MethodName",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Motorcycles",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Motorcycles",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Invoices",
                newName: "StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rentals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MotocycleBrands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleBrands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "MotocycleStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "MotocycleTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_BrandId",
                table: "Motorcycles",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TypeId",
                table: "Motorcycles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_MotocycleStatus_StatusId",
                table: "Invoices",
                column: "StatusId",
                principalTable: "MotocycleStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
