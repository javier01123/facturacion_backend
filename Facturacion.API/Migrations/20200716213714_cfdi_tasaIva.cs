﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.API.Migrations
{
    public partial class cfdi_tasaIva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TasaIva",
                table: "Cfdi",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TasaIva",
                table: "Cfdi");
        }
    }
}
