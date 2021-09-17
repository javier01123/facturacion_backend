using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTests.UseCases.Empresas
{
    [TestFixture]
    public class AltaEmpresaCommandHandlerTests
    {

        [Test]
        public async Task test_alta_empresa_valida()
        {
             
            var handler = new AltaEmpresaCommandHandler();

            var request = new AltaEmpresaCommand()
            {
                Id = Guid.NewGuid(),
                Rfc = "XAXX010101000",
                RazonSocial = "razon social demo",
                NombreComercial = "nombre comercial x"
            };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(result, Unit.Value);            
        }
        //RfcEmpresaDuplicadoException

        [Test]
        public void test_alta_con_rfc_duplicado()
        {
            var empresa = Empresa.Create(Guid.NewGuid(), "XAXX010101000", "razonSocial", "nombreComercial");              
            var handler = new AltaEmpresaCommandHandler();

            var request = new AltaEmpresaCommand()
            {
                Id = Guid.NewGuid(),
                Rfc = "XAXX010101000",
                RazonSocial = "razon social demo",
                NombreComercial = "nombre comercial x"
            };

            Assert.ThrowsAsync<RfcEmpresaDuplicadoException>(async () => await handler.Handle(request, CancellationToken.None)); 
        }

    }
}
