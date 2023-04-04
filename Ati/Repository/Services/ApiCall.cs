using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ApiCall : IApiCall
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ApiCall(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            var client = _httpClientFactory.CreateClient("httpBinClient");
            return client.GetAsync(url);
        }
    }
}
