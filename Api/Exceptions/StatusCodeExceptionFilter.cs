using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dukkantek.Api.Exceptions
{
    public class StatusCodeExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case RespondBadRequestException exception:
                    context.ModelState.AddModelError(exception.BadProperty, exception.Message);
                    context.Result = new BadRequestObjectResult(context.ModelState);

                    context.ExceptionHandled = true;
                    break;

                case RespondNotFoundException:
                    context.Result = new NotFoundResult();
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}
