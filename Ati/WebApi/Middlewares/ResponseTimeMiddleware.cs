using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    public class ResponseTimeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Log.Logger.Information($"Request To {context.Request.GetDisplayUrl()} - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            context.Response.OnStarting(() =>
            {
                stopWatch.Stop();
                Log.Logger.Information(
                    $"Response From {context.Request.GetDisplayUrl()} - " +
                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} - " +
                    $"{stopWatch.ElapsedMilliseconds.ToString()}");
                return Task.CompletedTask;
            });

            await next(context);
        }
    }
}
