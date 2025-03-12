using System.Net;
using System.Text.Json;
using LearningHub.App.Exceptions;

namespace LearningHub.WebApi.Middleware
{
    public class ErrorsMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecordNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var responce = new { message = ex.Message };

            await context.Response.WriteAsync(JsonSerializer.Serialize(responce));
        }
    }
}
