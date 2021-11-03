using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        
        private readonly ILogger<ResponseLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogResponseAsync(context);
        }
        
        private async Task LogResponseAsync(HttpContext context)
        {
            try
            {
                var originalResponseBody = context.Response.Body;
                    await using var responseBody = new MemoryStream();
                    context.Response.Body = responseBody;

                    await _next(context);

                    var bodyAsText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    var headersAsText = string.Join("<br/>", context.Response.Headers);
                    
                    _logger.LogInformation("Logging HTTP response");
                    _logger.LogInformation(
                        $"Response header {headersAsText}," + 
                        $"response body {bodyAsText}");
                    
                    await responseBody.CopyToAsync(originalResponseBody);
            }
            catch (Exception e)
            {
                _logger.LogError($"Logging response error {e.Message}");
            }
        }
    }
}