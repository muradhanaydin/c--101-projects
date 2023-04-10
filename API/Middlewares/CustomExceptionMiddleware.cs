using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using api.Services;

namespace api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public CustomExceptionMiddleware(RequestDelegate _next , ILoggerService _logger)
        {
            this._next = _next;
            this._logger = _logger;
        }

        public async Task Invoke(HttpContext _context)
        {
            var watch = Stopwatch.StartNew();
            try{
                string message = $"[Request] HTTP {_context.Request.Method} - {_context.Request.Path}";
                await _next(_context);
                watch.Stop();
                message = $"[Response] HTTP {_context.Request.Method} - {_context.Request.Path} responded {_context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds} ms";
                _logger.Write(message);
            }catch(Exception ex){
                watch.Stop();
                await HandleException(_context , ex , watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = $"[Error] HTTP {context.Request.Method} - {context.Request.Path} {context.Response.StatusCode} Error Message: {ex.Message} {watch.Elapsed.TotalMilliseconds} ms";
            _logger.Write(message);
            var result = JsonConvert.SerializeObject(new {error = ex.Message} , Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}