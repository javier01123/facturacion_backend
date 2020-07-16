using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            if (!Request.Cookies.ContainsKey("jwt_token"))
                return AuthenticateResult.Fail("Missing jwt_token");
    
            string userName = string.Empty;

            var jwtCookie = Request.Cookies["jwt_token"];
            string jwtToken = jwtCookie;
            //User user = null;
            try
            {

                if (!JwtManager.ValidateToken(jwtToken, out userName))
                    return AuthenticateResult.Fail("Invalid Token");

                //TODO: que hago una vez que tengo el nombre de usuario. o id del usuario?
                //si ya tiene el token es porque el token es valido y fue creado con el secret.
                //entonces su login y está autorizado.
                //user = await _userService.Authenticate(username, password);
            }
            catch
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
