﻿using GerenciamentoComercio_Domain.ErrorHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GerenciamentoComercio_API.Tools.ExceptionHandler
{
    public class ModelStateValidationFailedResult : ObjectResult
    {
        public ModelStateValidationFailedResult(ModelStateDictionary modelState)
            : base(new ErrorResponse(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
