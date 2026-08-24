namespace Cataloger.Api.Middlewares {
    public class ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger) {

        public async Task InvokeAsync(HttpContext context) {
            try {
                await next(context);
            } catch (Exception exception) {
                logger.LogError(
                    exception,
                    "An unhandled exception occurred while {Method} {Path}.",
                    context.Request.Method,
                    context.Request.Path
                );
                await HandleExceptionAsync(context);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new {
                message = "An unexpected error occurred. Please try again later."
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}