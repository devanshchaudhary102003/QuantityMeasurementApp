using QMAOperationService.Exception;
using System.Net;
using System.Text.Json;

namespace QMAOperationService.Middleware
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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (QuantityMeasurementException ex)
            {
                _logger.LogWarning(ex, "[QMAOperationService] Business exception");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var response = JsonSerializer.Serialize(new
                {
                    message = ex.Message,
                    service = "QMAOperationService"
                });
                await context.Response.WriteAsync(response);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "[QMAOperationService] Unhandled exception");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = JsonSerializer.Serialize(new
                {
                    message = ex.Message,
                    service = "QMAOperationService"
                });
                await context.Response.WriteAsync(response);
            }
        }
    }
}
