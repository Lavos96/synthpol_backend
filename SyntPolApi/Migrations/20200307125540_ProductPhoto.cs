using Microsoft.EntityFrameworkCore.Migrations;

namespace SyntPolApi.Migrations
{
    public partial class ProductPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GetInvoices_InvoiceId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetInvoices",
                table: "GetInvoices");

            migrationBuilder.RenameTable(
                name: "GetInvoices",
                newName: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "PhotoString",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PhotoString",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "GetInvoices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetInvoices",
                table: "GetInvoices",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GetInvoices_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                principalTable: "GetInvoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
