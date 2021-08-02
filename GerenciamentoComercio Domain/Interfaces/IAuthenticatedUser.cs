using System.Collections.Generic;
using System.Security.Claims;

namespace GerenciamentoComercio_Domain.Interfaces
{
    public interface IAuthenticatedUser
    {
        string Name { get; }
        IEnumerable<Claim> GetClaims();
        bool HasClaim(string type, string value);
        bool IsAuthenticated();
        string GetAccess();
        int GetId();
        bool IsAdministrator();
    }
}
