using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Facturacion.API.auth;
using Facturacion.API.Config;
using Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Facturacion.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : BaseController
    {

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost()]
        public async Task<IActionResult> Authenticate([FromBody] ValidarCredencialesCommand command)
        {

            ValidarCredencialesResult resultado = await Mediator.Send(command);

            string token = JwtManager.GenerateToken(command.Email.Trim());

            var cookieOptions = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            };

            Response.Cookies.Append("jwt_token", token, cookieOptions);
            return Ok(resultado);
        }


        [AllowAnonymous]
        [Route("logout")]
        [HttpGet()]
        public async Task<IActionResult> Logout()
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(-1),
                HttpOnly = true,
            };

            Response.Cookies.Append("jwt_token", "", cookieOptions);
            return Ok();
        }
    }
}