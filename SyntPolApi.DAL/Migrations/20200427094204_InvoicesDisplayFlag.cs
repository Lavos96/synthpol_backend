using Microsoft.EntityFrameworkCore.Migrations;

namespace SyntPolApi.DAL.Migrations
{
    public partial class InvoicesDisplayFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShallDisplay",
                table: "Invoices",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShallDisplay",
                table: "Invoices");
        }
    }
}
