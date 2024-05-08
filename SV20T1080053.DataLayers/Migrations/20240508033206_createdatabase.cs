using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SV20T1080053.DataLayers.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotocycleBrands",
                columns: table => new
                {
                    BrandID = table.Column<int>(name: "Brand_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<int>(name: "Brand_Name", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleBrands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "MotocycleStatus",
                columns: table => new
                {
                    SatatusID = table.Column<int>(name: "Satatus_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<int>(name: "Status_Name", type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleStatus", x => x.SatatusID);
                });

            migrationBuilder.CreateTable(
                name: "MotocycleType",
                columns: table => new
                {
                    TypeID = table.Column<int>(name: "Type_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotocycleType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    MethodsID = table.Column<int>(name: "Methods_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<int>(name: "Method_Name", type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.MethodsID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(name: "User_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(name: "Full_Name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<string>(name: "Birth_Date", type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    MotorcycleID = table.Column<int>(name: "Motorcycle_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(name: "User_ID", type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RentalPrice = table.Column<decimal>(name: "Rental_Price", type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID1 = table.Column<int>(name: "User_ID1", type: "int", nullable: false),
                    MotocycleTypeTypeID = table.Column<int>(name: "MotocycleTypeType_ID", type: "int", nullable: false),
                    MotocycleBrandBrandID = table.Column<int>(name: "MotocycleBrandBrand_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.MotorcycleID);
                    table.ForeignKey(
                        name: "FK_Motorcycles_MotocycleBrands_MotocycleBrandBrand_ID",
                        column: x => x.MotocycleBrandBrandID,
                        principalTable: "MotocycleBrands",
                        principalColumn: "Brand_ID");
                    table.ForeignKey(
                        name: "FK_Motorcycles_MotocycleType_MotocycleTypeType_ID",
                        column: x => x.MotocycleTypeTypeID,
                        principalTable: "MotocycleType",
                        principalColumn: "Type_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motorcycles_Users_User_ID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(name: "Rental_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(name: "User_ID", type: "int", nullable: false),
                    MotorcycleID = table.Column<int>(name: "Motorcycle_ID", type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(name: "Start_Date", type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(name: "End_Date", type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(name: "Total_Price", type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID1 = table.Column<int>(name: "User_ID1", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_User_ID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(name: "Invoice_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalID = table.Column<int>(name: "Rental_ID", type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(name: "Total_Amount", type: "decimal(18,2)", maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(name: "Invoice_Date", type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(name: "Payment_Date", type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MotocycleStatusSatatusID = table.Column<int>(name: "MotocycleStatusSatatus_ID", type: "int", nullable: false),
                    RentalID1 = table.Column<int>(name: "Rental_ID1", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_MotocycleStatus_MotocycleStatusSatatus_ID",
                        column: x => x.MotocycleStatusSatatusID,
                        principalTable: "MotocycleStatus",
                        principalColumn: "Satatus_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Rentals_Rental_ID1",
                        column: x => x.RentalID1,
                        principalTable: "Rentals",
                        principalColumn: "Rental_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(name: "Payment_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalID = table.Column<int>(name: "Rental_ID", type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(name: "Payment_Method", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentDate = table.Column<DateTime>(name: "Payment_Date", type: "datetime2", nullable: false),
                    RentalID1 = table.Column<int>(name: "Rental_ID1", type: "int", nullable: false),
                    PaymentMethodMethodsID = table.Column<int>(name: "PaymentMethodMethods_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethods_PaymentMethodMethods_ID",
                        column: x => x.PaymentMethodMethodsID,
                        principalTable: "PaymentMethods",
                        principalColumn: "Methods_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Rentals_Rental_ID1",
                        column: x => x.RentalID1,
                        principalTable: "Rentals",
                        principalColumn: "Rental_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_MotocycleStatusSatatus_ID",
                table: "Invoices",
                column: "MotocycleStatusSatatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Rental_ID1",
                table: "Invoices",
                column: "Rental_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MotocycleBrandBrand_ID",
                table: "Motorcycles",
                column: "MotocycleBrandBrand_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MotocycleTypeType_ID",
                table: "Motorcycles",
                column: "MotocycleTypeType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_User_ID1",
                table: "Motorcycles",
                column: "User_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodMethods_ID",
                table: "Payment",
                column: "PaymentMethodMethods_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Rental_ID1",
                table: "Payment",
                column: "Rental_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_User_ID1",
                table: "Rentals",
                column: "User_ID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "MotocycleStatus");

            migrationBuilder.DropTable(
                name: "MotocycleBrands");

            migrationBuilder.DropTable(
                name: "MotocycleType");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
