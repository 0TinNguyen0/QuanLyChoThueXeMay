using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class createdatabasev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentMethods_PaymentMethodMethods_ID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Rentals_Rental_ID1",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_Rental_ID1",
                table: "Payments",
                newName: "IX_Payments_Rental_ID1");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_PaymentMethodMethods_ID",
                table: "Payments",
                newName: "IX_Payments_PaymentMethodMethods_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Payment_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodMethods_ID",
                table: "Payments",
                column: "PaymentMethodMethods_ID",
                principalTable: "PaymentMethods",
                principalColumn: "Methods_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Rentals_Rental_ID1",
                table: "Payments",
                column: "Rental_ID1",
                principalTable: "Rentals",
                principalColumn: "Rental_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodMethods_ID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Rentals_Rental_ID1",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_Rental_ID1",
                table: "Payment",
                newName: "IX_Payment_Rental_ID1");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_PaymentMethodMethods_ID",
                table: "Payment",
                newName: "IX_Payment_PaymentMethodMethods_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Payment_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentMethods_PaymentMethodMethods_ID",
                table: "Payment",
                column: "PaymentMethodMethods_ID",
                principalTable: "PaymentMethods",
                principalColumn: "Methods_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Rentals_Rental_ID1",
                table: "Payment",
                column: "Rental_ID1",
                principalTable: "Rentals",
                principalColumn: "Rental_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
