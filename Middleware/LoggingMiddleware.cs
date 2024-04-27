namespace TaskList_API.Middleware
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate next;
        private readonly ILogger<LoggingMiddleware> logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next) 
        { 
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //registrar informacion entrante
            logger.LogInformation($"Request:{context.Request.Method} {context.Request.Path} from {context.Connection.RemoteIpAddress} at {DateTime.UtcNow}");

            await next(context);

            //registrar informacion saliente
            logger.LogInformation($"Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path} at {DateTime.UtcNow}");
        }
    }


    




    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
