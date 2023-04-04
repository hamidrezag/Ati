using Domain.Entities;
using Domain.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Policy;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheServices;
        public BaseController(IConfiguration configuration, ICacheService cacheServices)
        {
            _configuration = configuration;
            _cacheServices = cacheServices;
        }
        
        protected async Task<string> CacheResponse(string key , Func<Task<string>> func)
        {
            var cacheData = _cacheServices.GetData<ResponseContent>(key);
            if (cacheData != null)
                return cacheData.Content;
            var res = await func();
            var expirationTime = DateTimeOffset.Now.AddSeconds(_configuration.GetValue<int>("CacheSeconds"));
            _cacheServices.SetData(key, new ResponseContent
            {
                Content = res
            }, expirationTime);
            return res;
        }
    }
}
