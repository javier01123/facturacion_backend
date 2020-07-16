using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.API.Migrations
{
    public partial class foreign_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
               name: "FK_Sucursal_Empresa_EmpresaId",
               table: "Sucursal",
               column: "EmpresaId",
               principalTable: "Empresa",
               principalColumn: "Id",
               schema: "public",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Empresa_EmpresaId",
                table: "Cliente",
                column: "EmpresaId",
                principalTable: "Empresa",
                 principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Sucursal_Empresa_EmpresaId", "Sucursal");
            migrationBuilder.DropForeignKey("FK_Cliente_Empresa_EmpresaId", "Cliente");          
        }
    }
}
