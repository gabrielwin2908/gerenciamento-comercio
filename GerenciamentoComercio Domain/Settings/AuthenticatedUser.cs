using GerenciamentoComercio_Domain.Extensions;
using GerenciamentoComercio_Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace GerenciamentoComercio_Domain
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        private readonly IHttpContextAccessor _httpContextAcessor;

        public AuthenticatedUser(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAcessor = httpContextAcessor;
        }

        public string Name => _httpContextAcessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaims()
        {
            return _httpContextAcessor.HttpContext.User.Claims;
        }

        public bool HasClaim(string type, string value)
        {
            return _httpContextAcessor.HttpContext.User.HasClaim(type, value);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAcessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public string GetAccess()
        {
            return _httpContextAcessor.HttpContext.User.GetAccess();
        }

        public int GetId()
        {
            return _httpContextAcessor.HttpContext.User.GetId();
        }

        public bool IsAdministrator()
        {
            return _httpContextAcessor.HttpContext.User.IsAdministrator();
        }
    }
}
