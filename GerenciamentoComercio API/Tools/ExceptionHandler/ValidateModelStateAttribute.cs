using Microsoft.AspNetCore.Mvc.Filters;

namespace GerenciamentoComercio_API.Tools.ExceptionHandler
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool invalidModelState = context.ModelState.IsValid == false;

            if (invalidModelState)
            {
                context.Result = new ModelStateValidationFailedResult(context.ModelState);
            }
        }
    }
}
