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
        public async Task Handle_ValidRequest_DebeSerExitoso()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var empresaRepository = Substitute.For<IEmpresaRepository>();
            var sucursalRepository = Substitute.For<ISucursalRepository>();
            var handler = new AltaEmpresaCommandHandler(unitOfWork, empresaRepository, sucursalRepository);

            var request = new AltaEmpresaCommand()
            {
                Id = Guid.NewGuid(),
                Rfc = "XAXX010101000",
                RazonSocial = "razon social demo",
                NombreComercial = "nombre comercial x"
            };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(result, Unit.Value);
            empresaRepository.Received().AddEmpresa(Arg.Any<Empresa>());
            sucursalRepository.Received().AddSucursal(Arg.Any<Sucursal>());
            Received.InOrder(async () => await unitOfWork.SaveChangesAsync(Arg.Any<CancellationToken>()));
        }
        //RfcEmpresaDuplicadoException

        [Test]
        public void Handle_RfcExistente_DebeLanzarRfcEmpresaDuplicadoEx()
        {
            var empresa = Empresa.Create(Guid.NewGuid(), "XAXX010101000", "razonSocial", "nombreComercial");
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var empresaRepository = Substitute.For<IEmpresaRepository>();
            empresaRepository.FindByRfc(Arg.Any<Rfc>()).Returns(empresa);
            var sucursalRepository = Substitute.For<ISucursalRepository>();
            var handler = new AltaEmpresaCommandHandler(unitOfWork, empresaRepository, sucursalRepository);

            var request = new AltaEmpresaCommand()
            {
                Id = Guid.NewGuid(),
                Rfc = "XAXX010101000",
                RazonSocial = "razon social demo",
                NombreComercial = "nombre comercial x"
            };

            Assert.ThrowsAsync<RfcEmpresaDuplicadoException>(async () => await handler.Handle(request, CancellationToken.None));
            empresaRepository.DidNotReceive().AddEmpresa(Arg.Any<Empresa>());
            sucursalRepository.DidNotReceive().AddSucursal(Arg.Any<Sucursal>());
        }

    }
}
