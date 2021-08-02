using GerenciamentoComercio_API.v1.Common;
using GerenciamentoComercio_Domain.DTOs.Request;
using GerenciamentoComercio_Domain.DTOs.Response;
using GerenciamentoComercio_Domain.Interfaces;
using GerenciamentoComercio_Domain.Utils;
using GerenciamentoComercio_Domain.v1.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Sistema_Incidentes.v1.Controllers
{
    [Route("v{version:apiVersion}/auth/")]
    [ApiVersion("1.0")]
    public class AuthenticationController : MainController
    {
        private readonly IAuthenticationServices _authenticationServices;

        public AuthenticationController(IAuthenticatedUser authenticatedUser,
            IAuthenticationServices authenticationServices) : base(authenticatedUser)
        {
            _authenticationServices = authenticationServices;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [SwaggerOperation("Authenticate user")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(LoginResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.", typeof(string))]
        public IActionResult Login(LoginRequest request)
        {

            //return Ok(_authenticationServices.Login(request));
            var response = _authenticationServices.Login(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)response.StatusCode, response.Content);
            }

            return StatusCode((int)response.StatusCode, response.ContentObj);
        }
    }
}
