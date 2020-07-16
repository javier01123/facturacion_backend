using Facturacion.Domain.Aggregates;
using Facturacion.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.IntegrationTests.Common
{
    public static class SeedData
    {
        public static void InitializeDbForTests(FacturacionContext context)
        {
            var usuarioDefault = Usuario.Create(Guid.NewGuid(), "admin@noserver.com", "mypass");
            context.Usuario.Add(usuarioDefault);

            var empresaId = Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11");
            var empresa = Empresa.Create(empresaId, "XAXX010101000", "Razón social test", "Nombre comercial test");
            context.Empresa.Add(empresa);

            var sucursalId = Guid.Parse("28295566-3c6b-42c4-850e-f36d5d4faaac");
            var sucursal = Sucursal.Create(sucursalId, empresaId, "Sucursal Matriz");
            context.Sucursal.Add(sucursal);

            var clienteId = Guid.Parse("c58db24a-37cd-4a43-a9a1-e7247c79323d");
            var cliente = Cliente.Create(clienteId, empresaId, "XAXX010101000", "Cliente SA de CV");
            context.Cliente.Add(cliente);

            var cfdiId = Guid.Parse("0ccfba72-efdb-4869-a975-de51cecae97c");
            var fechaEmision = new DateTime(2020, 7, 20, 13, 0, 0);
            var serie = "f";
            var folio = 1;
            var cfdi = Cfdi.Create(cfdiId, clienteId, sucursalId, fechaEmision, serie, folio);

            var partidaId = Guid.Parse("74f1da12-c234-476c-a574-3a80d7648595");
            cfdi.AgregarPartida(partidaId, 1, 1, "partida de prueba");
            context.Cfdi.Add(cfdi);

            context.SaveChanges();
        }
    }
}
