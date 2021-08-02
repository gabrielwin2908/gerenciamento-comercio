using GerenciamentoComercio_API.Tools.ExceptionHandler;
using GerenciamentoComercio_Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoComercio_API.v1.Common
{
    [ApiController]
    [ValidateModelState]
    public abstract class MainController : ControllerBase
    {
        protected int AuthUserId { get; set; }
        protected string AuthUserAccess { get; set; }

        public MainController(IAuthenticatedUser authenticatedUser)
        {
            AuthUserId = authenticatedUser.GetId();
            AuthUserAccess = authenticatedUser.GetAccess();
        }
    }
}
