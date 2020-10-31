using System;
using System.Collections.Generic;
using System.Text;

namespace API.IntegrationTests.Common
{
    class AuthResponse
    {
        public string token { get; set; }
        public AuthResponseUser user { get; set; }

    }

   class AuthResponseUser
    {
        public string id { get; set; }
        public string email { get; set; }
    }
}
