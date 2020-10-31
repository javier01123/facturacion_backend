using Facturacion.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Common
{
    public class ControllerTestBase
    {
        protected CustomWebApplicationFactory<Startup> _factory;
        protected HttpClient _authenticatedHttpClient;

        [SetUp]
        public async virtual Task SetUp()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _authenticatedHttpClient = await _factory.GetAuthenticatedClient();
        }

    }
}
