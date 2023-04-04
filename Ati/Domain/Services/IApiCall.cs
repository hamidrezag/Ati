using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IApiCall
    {
        public Task<HttpResponseMessage> GetAsync(string url);
    }
}
