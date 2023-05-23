namespace ThhTransTracker.API.CustomMiddlewares
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
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)GetStatusCode(ex);

            _logger.LogError("Error Processing Request", ex.ToString());

            string errorMessage = ex.InnerException?.Message ?? ex.Message;

            Error error = new(httpContext.Response.StatusCode, errorMessage);
            JsonSerializerSettings serializerSettings = new() { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            var result = new Result<Error>
            {
                Error = error,
                ErrorMessage = errorMessage,
                IsSuccess = false
            };

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result, serializerSettings));
        }

        private static HttpStatusCode GetStatusCode(Exception ex)
        {
            if (ex is not BaseException internalException)
            {
                return HttpStatusCode.InternalServerError;
            }
            return internalException.StatusCode;
        }
    }
}
