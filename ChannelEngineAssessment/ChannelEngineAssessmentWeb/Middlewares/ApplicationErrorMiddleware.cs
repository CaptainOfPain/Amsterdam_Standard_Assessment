using System;
using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ChannelEngineAssessmentWeb.Middlewares
{
    public class ApplicationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApplicationExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                string message;
                if (ex is BusinessLogicException)
                {
                    message = ex.Message;
                }
                else
                {
                    message = "An error occurred";
                }

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = "application/json; charset=utf-8";
                httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                string json = JsonConvert.SerializeObject(new { message = message });
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
