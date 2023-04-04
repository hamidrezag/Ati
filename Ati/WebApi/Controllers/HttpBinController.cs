using Domain.Entities;
using Domain.Repo;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// فراخوانی WebApi
    /// </summary>
    public class HttpBinController : BaseController
    {
        private readonly IApiCall _apiCall;
        private readonly IConfiguration _configuration;

        public HttpBinController(IApiCall apiCall, 
            IConfiguration configuration, 
            ICacheService cacheServices)
            :base(configuration, cacheServices)
        {
            _apiCall = apiCall ?? throw new ArgumentNullException();
            _configuration = configuration ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// گرفتن اطلاعات
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = _configuration.GetValue<string>("Url");
            return Content(await CacheResponse(url,async () => {
                HttpResponseMessage res = await _apiCall.GetAsync(url);
                return await res.Content.ReadAsStringAsync();
            }));
            
        }
    }
}
