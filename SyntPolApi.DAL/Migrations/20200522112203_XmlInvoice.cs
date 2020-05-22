using Microsoft.EntityFrameworkCore.Migrations;

namespace SyntPolApi.DAL.Migrations
{
    public partial class XmlInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "XmlString",
                table: "InvoicesEdi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XmlString",
                table: "InvoicesEdi");
        }
    }
}
