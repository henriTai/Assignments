using Microsoft.AspNetCore.Builder;

namespace web_api.Middleware
{
    public static class MiddwareExtensions
    {
        public static void UseGlobalErrorHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandling.GlobalErrHandler>();
        }
    }
}