using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Web.Http.ExceptionHandling;

namespace App.Endpoint.API.MiddleWares
{
    public class ErrorHandleMiddleWare : IMiddleware
    {
        private readonly ILogger<ErrorHandleMiddleWare> _logger;

        public ErrorHandleMiddleWare(ILogger<ErrorHandleMiddleWare> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);

            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var result = string.Empty;
            if (ex is ArgumentException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (ex is ExceptionCatchBlocks)
            {
                code = HttpStatusCode.BadGateway;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            context.Response.WriteAsync(result);
            return Task.CompletedTask;
        }

    }
}
