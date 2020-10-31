using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Facturacion.API.auth
{
    public class JwtAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        public JwtAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string userName = string.Empty;

            try
            {
                var bearerToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", string.Empty);

                if (!JwtManager.ValidateToken(bearerToken, out userName))
                    return AuthenticateResult.Fail("Invalid Token");
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("Invalid Authentication");
            }

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,"id_de_usuario_estatico" ),
                new Claim(ClaimTypes.Name, userName),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
