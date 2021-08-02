using GerenciamentoComercio_Domain.ErrorHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GerenciamentoComercio_API.Tools.ExceptionHandler
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionHandlerController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;
        public ExceptionHandlerController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [Route("error")]
        public ErrorResponse HandleException()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            if (exception is HttpException httpException)
            {
                Response.StatusCode = (int)httpException.StatusCode;
                return new ErrorResponse(httpException.Errors);
            }

            if (_hostEnvironment.IsDevelopment() == false)
            {
                if (exception is DbUpdateException)
                {
                    Response.StatusCode = 500;
                    return new ErrorResponse("Não foi possível finalizar o processo. Por favor, entre em contato com o suporte.");
                }
                else if (exception is SqlException)
                {
                    Response.StatusCode = 500;
                    return new ErrorResponse("Não foi possível finalizar o processo. Por favor, entre em contato com o suporte.");
                }
            }

            Response.StatusCode = 500;
            return new ErrorResponse(exception.Message);
        }
    }
}
