using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middlewares
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

        public async Task Invoke(HttpContext context)
        {
            await using var requestBodyStream = new MemoryStream();
            await using var responseBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;
            context.Request.EnableBuffering();
            var originalResponseBody = context.Response.Body;

            try
            {
                await context.Request.Body.CopyToAsync(requestBodyStream);
                requestBodyStream.Seek(0, SeekOrigin.Begin);

                var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

                requestBodyStream.Seek(0, SeekOrigin.Begin);
                context.Request.Body = requestBodyStream;
                
                context.Response.Body = responseBodyStream;

                var watch = Stopwatch.StartNew();
                await _next(context);
                watch.Stop();

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = new StreamReader(responseBodyStream).ReadToEnd();
                _logger.LogInformation("Host: {0}\n " +
                                       "Route: {1}\n " +
                                       "QueryParams: {2}\n " +
                                       "IP: {3}\n " +
                                       "Headers: {4}\n " +
                                       "Request Body: {5}\n " +
                                       "Response Body: {6}\n " +
                                       "Date Time: {7}\n " +
                                       "Responded in : {8} ms",
                    context.Request.Host.Host,
                    context.Request.Path, 
                    context.Request.QueryString.ToString(),
                    context.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                    string.Join(",", context.Request.Headers.Select(he => he.Key + ":[" + he.Value + "]").ToList()),
                    requestBodyText, 
                    responseBody, 
                    DateTime.Now, 
                    watch.ElapsedMilliseconds);

                responseBodyStream.Seek(0, SeekOrigin.Begin);

                await responseBodyStream.CopyToAsync(originalResponseBody);
            }
            catch (Exception ex)
            {
                var data = Encoding.UTF8.GetBytes("Unhandled Error occured, the error has been logged and the persons concerned are notified!! Please, try again in a while.");
                await originalResponseBody.WriteAsync(data, 0, data.Length);
            }
            finally
            {
                context.Request.Body = originalRequestBody;
                context.Response.Body = originalResponseBody;
            }
        }
    }
}