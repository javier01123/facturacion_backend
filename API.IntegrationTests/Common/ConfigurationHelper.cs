using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.IntegrationTests.Common
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetTestConfiguration()
            => new ConfigurationBuilder()
                .AddJsonFile("integrationSettings.json")
                .Build();
    }
}
