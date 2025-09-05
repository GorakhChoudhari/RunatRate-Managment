

namespace RunAtRate.Core.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Serilog;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;

    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context); // Call the next middleware
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unhandled exception occurred"); // 🔥 Logs to Serilog/DB

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred. Please try again later."
                    // Optionally include: ex.Message, ex.StackTrace
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

}
