using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_QueryPractice.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUpdates",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GLAccounts",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    AccountDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccounts", x => x.AccountNo);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceArchive",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    InvoiceTotal = table.Column<decimal>(type: "money", nullable: false),
                    PaymentTotal = table.Column<decimal>(type: "money", nullable: false),
                    CreditTotal = table.Column<decimal>(type: "money", nullable: false),
                    TermsID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermsDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TermsDueDays = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermsID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VendorAddress1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VendorAddress2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VendorCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VendorState = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    VendorZipCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    VendorPhone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VendorContactLName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VendorContactFName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DefaultTermsID = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    DefaultAccountNo = table.Column<int>(type: "int", nullable: false, defaultValue: 570)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                    table.ForeignKey(
                        name: "FK_Vendors_GLAccounts",
                        column: x => x.DefaultAccountNo,
                        principalTable: "GLAccounts",
                        principalColumn: "AccountNo");
                    table.ForeignKey(
                        name: "FK_Vendors_Terms",
                        column: x => x.DefaultTermsID,
                        principalTable: "Terms",
                        principalColumn: "TermsID");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    InvoiceTotal = table.Column<decimal>(type: "money", nullable: false),
                    PaymentTotal = table.Column<decimal>(type: "money", nullable: false),
                    CreditTotal = table.Column<decimal>(type: "money", nullable: false),
                    TermsID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Terms",
                        column: x => x.TermsID,
                        principalTable: "Terms",
                        principalColumn: "TermsID");
                    table.ForeignKey(
                        name: "FK_Invoices_Vendors",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    InvoiceSequence = table.Column<short>(type: "smallint", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    InvoiceLineItemAmount = table.Column<decimal>(type: "money", nullable: false),
                    InvoiceLineItemDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => new { x.InvoiceID, x.InvoiceSequence });
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_GLAccounts",
                        column: x => x.AccountNo,
                        principalTable: "GLAccounts",
                        principalColumn: "AccountNo");
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Invoices",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_AccountNo",
                table: "InvoiceLineItems",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDate",
                table: "Invoices",
                column: "InvoiceDate",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TermsID",
                table: "Invoices",
                column: "TermsID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_VendorID",
                table: "Invoices",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorName",
                table: "Vendors",
                column: "VendorName");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_AccountNo",
                table: "Vendors",
                column: "DefaultAccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_TermsID",
                table: "Vendors",
                column: "DefaultTermsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUpdates");

            migrationBuilder.DropTable(
                name: "InvoiceArchive");

            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "GLAccounts");

            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
