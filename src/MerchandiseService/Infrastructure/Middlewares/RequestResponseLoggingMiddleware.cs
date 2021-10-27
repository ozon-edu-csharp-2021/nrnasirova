using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequestAsync(context);
            await LogResponseAsync(context);
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