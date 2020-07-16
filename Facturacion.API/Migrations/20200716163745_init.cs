using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cfdi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SucursalId = table.Column<Guid>(nullable: false),
                    Folio = table.Column<int>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    MetodoDePago = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(maxLength: 10, nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfdi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false),
                    RazonSocial = table.Column<string>(maxLength: 50, nullable: true),
                    Rfc = table.Column<string>(maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rfc = table.Column<string>(maxLength: 13, nullable: true),
                    NombreComercial = table.Column<string>(maxLength: 100, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CfdiId = table.Column<Guid>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Importe = table.Column<decimal>(nullable: false),
                    ValorUnitario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Cfdi_CfdiId",
                        column: x => x.CfdiId,
                        principalTable: "Cfdi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteDomicilio",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    Calle = table.Column<string>(maxLength: 50, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 25, nullable: true),
                    CodigoPostal = table.Column<string>(maxLength: 10, nullable: true),
                    Colonia = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 25, nullable: true),
                    Municipio = table.Column<string>(maxLength: 25, nullable: true),
                    NumeroExterior = table.Column<string>(maxLength: 10, nullable: true),
                    NumeroInterior = table.Column<string>(maxLength: 10, nullable: true),
                    Pais = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteDomicilio", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_ClienteDomicilio_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SucursalDomicilio",
                columns: table => new
                {
                    SucursalId = table.Column<Guid>(nullable: false),
                    Calle = table.Column<string>(maxLength: 50, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 25, nullable: true),
                    CodigoPostal = table.Column<string>(maxLength: 10, nullable: true),
                    Colonia = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 25, nullable: true),
                    Municipio = table.Column<string>(maxLength: 25, nullable: true),
                    NumeroExterior = table.Column<string>(maxLength: 10, nullable: true),
                    NumeroInterior = table.Column<string>(maxLength: 10, nullable: true),
                    Pais = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalDomicilio", x => x.SucursalId);
                    table.ForeignKey(
                        name: "FK_SucursalDomicilio_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cfdi_ClienteId",
                table: "Cfdi",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EmpresaId",
                table: "Cliente",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDomicilio_ClienteId",
                table: "ClienteDomicilio",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Rfc",
                table: "Empresa",
                column: "Rfc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_CfdiId",
                table: "Partida",
                column: "CfdiId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_EmpresaId",
                table: "Sucursal",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalId",
                table: "SucursalDomicilio",
                column: "SucursalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteDomicilio");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "SucursalDomicilio");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cfdi");

            migrationBuilder.DropTable(
                name: "Sucursal");
        }
    }
}
