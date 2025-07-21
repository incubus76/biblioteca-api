namespace BibliotecaAPI
{
    public class LogueaPeticionMiddleware
    {
        private readonly RequestDelegate next;

        public LogueaPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async void InvokeAsync(HttpContext context)
        {
            //Viene la petición
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"Petición: {context.Request.Method} {context.Request.Path}");
            await next.Invoke(context);
            logger.LogInformation($"Respuesta: {context.Response.StatusCode}");
        }
    }

    public static class LogueaPeticionMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogueaPeticion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogueaPeticionMiddleware>();
        }
    }
}
