using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequestAsync(context);
            await _next(context);
        }

        private async Task LogRequestAsync(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();
                    var buffer = new byte[context.Request.ContentLength.Value];
                    await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                    var bodyAsText = Encoding.UTF8.GetString(buffer);
                    var headersAsText = string.Join("<br/>", context.Request.Headers.OrderBy(x => x));
                    var route = string.Join("<br/>", context.Request.RouteValues.OrderBy(x => x));
                    _logger.LogInformation("Logging HTTP request");
                    _logger.LogInformation(
                        $"Request header {headersAsText}," +
                        $"request route {route}," +
                        $"request body {bodyAsText}");
                    
                    context.Request.Body.Position = 0;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Logging request error {e.Message}");
            }
        }
    }
}