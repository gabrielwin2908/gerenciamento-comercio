using System.Collections.Generic;
using System.Net;

namespace GerenciamentoComercio_Domain.ErrorHandler.ErrorStatusCodes
{
    public class ForbiddenException : HttpException
    {
        private static readonly HttpStatusCode _statusCode = HttpStatusCode.Forbidden;

        public ForbiddenException(string message) : base(message, _statusCode)
        {
        }

        public ForbiddenException(IList<string> messages) : base(messages, _statusCode)
        {
        }
    }
}
