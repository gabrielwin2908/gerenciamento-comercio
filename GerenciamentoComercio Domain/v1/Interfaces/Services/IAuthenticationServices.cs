using GerenciamentoComercio_Domain.DTOs.Request;
using GerenciamentoComercio_Domain.DTOs.Response;
using GerenciamentoComercio_Domain.Utils;

namespace GerenciamentoComercio_Domain.v1.Interfaces.Services
{
    public interface IAuthenticationServices
    {
        APIMessage Login(LoginRequest request);
    }
}
