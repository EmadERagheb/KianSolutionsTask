using Newtonsoft.Json;
using System.Net;
using WebApi.Helper;

namespace WebApi.MiddleWares
{
    public class ExceptionMiddleWare(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionMiddleWare> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment() ?
                    new CommonResponseDTO(500, ex.Message,ex.StackTrace) : new CommonResponseDTO(500);
                var serialize = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(serialize);
            }

        }
    }



}
