using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serko.XmlExtractor.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Serko.XmlExtactor.ExceptionHandling
{
    /// <summary>
    /// Middleware that can be registered to handle exceptions globally.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.Message);

            // Set HTTP code according to the exception
            var httpCode = DetermineHttpCode(exception);
            context.Response.StatusCode = (int)httpCode;

            // Set error message as JSON body
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }

        private static HttpStatusCode DetermineHttpCode(Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // default HTTP code for any exception

            if (exception is BusinessException businessException)
            {
                code = businessException.GetHttpCode();
            }

            return code;
        }
    }
}
