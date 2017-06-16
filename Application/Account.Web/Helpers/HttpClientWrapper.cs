using Account.Web.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Account.Web.Helpers
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient httpClient;

        public HttpClientWrapper()
        {
            httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.httpClient.SendAsync(request);
        }

        public Uri BaseAddress
        {
            get
            {
                return this.httpClient.BaseAddress;
            }
            set
            {
                this.httpClient.BaseAddress = value;
            }
        }
    }
}