using Account.Web.Helpers.Interfaces;
using Account.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Account.Web.Helpers
{
    public class ServiceResponseHelper : IServiceResponseHelper
    {
        private readonly IHttpClient httpClient;

        public ServiceResponseHelper(IHttpClient client)
        {
            this.httpClient = client;
        }
        /// <summary>
        /// Get respose from REST service.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="parameterDictionary"></param>
        /// <param name="mediaType"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public async Task<ServiceResponseModel> GetResponse(string url, HttpMethod method, IDictionary<string, string> parameterDictionary, string mediaType, Encoding encoding)
        {
            ServiceResponseModel serviceResponse = new ServiceResponseModel();
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    this.httpClient.BaseAddress = new Uri(url);
                    
                    if (parameterDictionary != null)
                    {
                        if (method == HttpMethod.Post)
                        {
                            StringBuilder requestContent = new StringBuilder("{");

                            foreach (var item in parameterDictionary)
                            {
                                requestContent.Append("\"" + item.Key + "\":" + "\"" + item.Value + "\",");
                            }

                            requestContent = requestContent.Replace(",", string.Empty, requestContent.Length - 1, 1);
                            requestContent.Append("}");
                            request.Content = new StringContent(requestContent.ToString(), encoding, mediaType);
                        }
                        else
                        {
                            var paramList = new List<string>();
                            foreach (var item in parameterDictionary)
                            {
                                paramList.Add(item.Key + "=" + item.Value);
                            }
                            var query = "?"+ string.Join("&", paramList);

                        this.httpClient.BaseAddress = new Uri(url + query);
                        }
                    }

                    request.Method = method;

                    var response = await this.httpClient.SendAsync(request);
                    serviceResponse.ResponsePhrase = response.ReasonPhrase;
                    serviceResponse.StatusCode = response.StatusCode;
                    serviceResponse.IsSuccessStatusCode = response.IsSuccessStatusCode;

                    if (response.Content != null)
                    {
                        serviceResponse.Content = await response.Content.ReadAsStringAsync();
                    }
                }

            return serviceResponse;
        }
    }
}