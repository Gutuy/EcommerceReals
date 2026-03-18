using Ecommerce.Api.Error;
using System.Net;
using System.Text.Json;

namespace Ecommerce.Api.MiddleWare
{
    public class ExceptionMiddleware(IHostEnvironment env ,RequestDelegate next)
    {

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex) {
                await HandleExpception(context, ex, env);
            }
        }

        private static Task HandleExpception(HttpContext context, Exception ex, IHostEnvironment env)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var Response = env.IsDevelopment() ? new ErrorResponseApi(context.Response.StatusCode, ex.Message, ex.StackTrace) :
                new ErrorResponseApi(context.Response.StatusCode, ex.Message, "Internal server error");

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json=JsonSerializer.Serialize(Response, options);
            return context.Response.WriteAsync(json);
        }
    }
}
