using Microsoft.AspNetCore.Builder;

namespace ChannelEngineAssessmentWeb.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApplicationExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApplicationExceptionMiddleware>();
        }
    }
}