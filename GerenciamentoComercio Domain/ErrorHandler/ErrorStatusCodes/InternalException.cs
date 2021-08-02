using System.Collections.Generic;
using System.Net;

namespace GerenciamentoComercio_Domain.ErrorHandler.ErrorStatusCodes
{
    public class InternalException : HttpException
    {
        private static readonly HttpStatusCode _statusCode = HttpStatusCode.InternalServerError;

        public InternalException(string message) : base(message, _statusCode)
        {
        }

        public InternalException(IList<string> messages) : base(messages, _statusCode)
        {
        }
    }
}
