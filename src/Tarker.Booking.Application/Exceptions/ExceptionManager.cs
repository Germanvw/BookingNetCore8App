using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(
                ResponseApiService.Response(
                    statusCode,
                    null,
                    context.Exception.Message
                ));

            context.HttpContext.Response.StatusCode = statusCode;
        }
    }
}
