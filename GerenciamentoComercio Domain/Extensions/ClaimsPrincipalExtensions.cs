using System;
using System.Security.Claims;

namespace GerenciamentoComercio_Domain.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetAccess(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));

            return claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));

            string id = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(id)) return 0;

            return int.Parse(id);
        }

        public static bool IsAdministrator(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));

            string isAdministrator = claimsPrincipal.FindFirst("IsAdministrator")?.Value;
            if (string.IsNullOrEmpty(isAdministrator)) return false;

            return bool.Parse(isAdministrator);
        }
    }
}
