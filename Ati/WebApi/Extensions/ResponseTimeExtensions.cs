using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi.Middlewares;

namespace WebApi.Extensions
{
    public static class ResponseTimeExtensions
    {
        public static IServiceCollection AddResponseTime(this IServiceCollection services)
        {
            services.TryAddSingleton<ResponseTimeMiddleware, ResponseTimeMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseResponseTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ResponseTimeMiddleware>();
        }
    }
}
