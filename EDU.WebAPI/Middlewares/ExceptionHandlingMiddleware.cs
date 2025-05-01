namespace EDU.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate _next, ILogger<ExceptionHandlingMiddleware> _logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var endpoint = context.GetEndpoint();
                var route = context.Request.Path;
                var method = context.Request.Method;
                _logger.LogError(ex, $"Xeta bas verdi{method}-{route}-{endpoint},");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var response = new
                {
                    message = "Xeta bas verdi",
                    route = route,
                    method = method,
                    detail = ex.Message
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
