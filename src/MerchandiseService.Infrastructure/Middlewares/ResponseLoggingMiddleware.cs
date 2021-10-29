using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogResponseAsync(context);
            await _next(context);
        }
        
        private async Task LogResponseAsync(HttpContext context)
        {
            try
            {
                if (context.Response.ContentLength > 0)
                {
                    var originalResponseBody = context.Response.Body;
                    await using var responseBody = new MemoryStream();
                    context.Response.Body = responseBody;

                    await _next(context);

                    var bodyAsText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                        
                    var headersAsText = string.Join("<br/>", context.Response.Headers.OrderBy(x => x));
                        
                    _logger.LogInformation("Logging HTTP response");
                    _logger.LogInformation(
                        $"Request header {headersAsText}," + 
                        $"request body {bodyAsText}");
                    
                    await responseBody.CopyToAsync(originalResponseBody);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Logging response error {e.Message}");
            }
        }
    }
}