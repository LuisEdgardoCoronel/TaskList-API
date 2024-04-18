namespace TaskList_API.Middleware
{
    public class ErrorMiddleware
    {
        readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                // Manejar la excepción y generar una respuesta adecuada
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error");

                // Registrar el error en un archivo de registro con Serilog o NLog
                // ej: logger.LogError(ex, "Error en la API");
            }
        }
    }





    public static class ErrorMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorMiddleware>();
        }
    }
}
