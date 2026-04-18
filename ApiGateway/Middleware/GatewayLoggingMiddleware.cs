namespace ApiGateway.Middleware
{
    public class GatewayLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GatewayLoggingMiddleware> _logger;

        public GatewayLoggingMiddleware(RequestDelegate next, ILogger<GatewayLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;
            _logger.LogInformation("[Gateway] --> {method} {path}",
                context.Request.Method, context.Request.Path);

            await _next(context);

            var ms = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogInformation("[Gateway] <-- {status} {path} ({ms}ms)",
                context.Response.StatusCode, context.Request.Path, ms);
        }
    }
}
