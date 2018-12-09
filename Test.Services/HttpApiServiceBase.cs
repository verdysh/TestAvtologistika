using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Test.Services
{
    abstract public class HttpApiServiceBase: ServiceBase
    {
        protected readonly HttpClient _client;

        public HttpApiServiceBase(string baseUrl, double timeOut = 0)
        {
            var handler = new HttpClientHandler()
            {
                CookieContainer = new CookieContainer()
            };
            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            if (timeOut > 0)
                _client.Timeout = TimeSpan.FromMilliseconds(timeOut);
        }

        public async Task<string> Get(string request = default(string))
        {
            var response = await _client.GetAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}