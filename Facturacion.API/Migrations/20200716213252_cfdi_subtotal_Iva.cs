using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.API.Migrations
{
    public partial class cfdi_subtotal_Iva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Iva",
                table: "Cfdi",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "Cfdi",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iva",
                table: "Cfdi");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "Cfdi");
        }
    }
}
