using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Serilog;
using Microsoft.AspNetCore.Http;

namespace WebApi.Middlewares
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string requestBody = "";
            if (request.Content != null)
                requestBody = await request.Content.ReadAsStringAsync();
            Log.Logger.Information($"Request Url - {request.RequestUri} : {requestBody}");
            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                var responseBody = await result.Content.ReadAsStringAsync();
                Log.Logger.Information($"Response From Url - {request.RequestUri} : {responseBody}");
            }

            return result;
        }
    }
}
