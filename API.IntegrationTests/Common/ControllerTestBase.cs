using Facturacion.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace API.IntegrationTests.Common
{
    public class ControllerTestBase
    {
        protected CustomWebApplicationFactory<Startup> _factory;
        protected HttpClient _authenticatedHttpClient;

        [SetUp]
        public virtual void SetUp()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _authenticatedHttpClient = _factory.GetAuthenticatedClient();
        }

    }
}
