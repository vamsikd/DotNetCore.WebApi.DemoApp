using DemoApp.API.Exceptions;
using System.Net;

namespace DemoApp.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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
            catch (NotFoundException ex)
            {
                // log error
                _logger.LogError(ex, "Details Not Found");
                // send error response
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.NotFound;
                await response.WriteAsJsonAsync(new { errorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                // log error
                _logger.LogError(ex, "Internal Server Error");
                // send error response
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsJsonAsync(new { errorMessage = ex.Message });
            }

        }


    }

}
