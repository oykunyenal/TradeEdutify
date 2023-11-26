using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Application.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NullReferenceException nullRefEx)
            {
                LogNullExceptionWithContext(nullRefEx, httpContext);
            }
            catch (ValidationException ex)
            {
                ValidationExceptionAsync(ex, httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        private void HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var request = httpContext.Request;

            // Get relevant request information
            var requestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
            var requestMethod = request.Method;
            var now = DateTime.UtcNow;
            _logger.LogError(ex, "An unhandled exception occurred: {RequestUrl} ({RequestMethod})", requestUrl, requestMethod);
        }

        private void LogNullExceptionWithContext(NullReferenceException nullRefEx, HttpContext context)
        {
            var request = context.Request;

            // Get relevant request information
            var requestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
            var requestMethod = request.Method;

            // Log the NullReferenceException with context information
            _logger.LogError(nullRefEx, "A NullReferenceException occurred: {RequestUrl} ({RequestMethod})", requestUrl, requestMethod);
        }

        private void ValidationExceptionAsync(ValidationException validationExceptionEx, HttpContext context)
        {
            var request = context.Request;

            // Get relevant request information
            var requestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
            var requestMethod = request.Method;

            // Log the NullReferenceException with context information
            _logger.LogError(validationExceptionEx, "A ValidationException occurred: {RequestUrl} ({RequestMethod})", requestUrl, requestMethod);
        }

    }
}
