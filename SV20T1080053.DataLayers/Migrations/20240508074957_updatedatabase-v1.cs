using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rental_ID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Motorcycles",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Motorcycle_ID",
                table: "Motorcycles",
                newName: "MotorcycleId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Invoices",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Payment_Date",
                table: "Invoices",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "Invoice_Date",
                table: "Invoices",
                newName: "InvoiceDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Motorcycles",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "Motorcycles",
                newName: "Motorcycle_ID");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Invoices",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Invoices",
                newName: "Payment_Date");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoices",
                newName: "Invoice_Date");

            migrationBuilder.AddColumn<int>(
                name: "Rental_ID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Motorcycles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
