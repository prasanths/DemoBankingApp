using Account.Web.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Account.Web.Tests.Helpers
{
    public class FakeHttpClient : IHttpClient
    {
        public Uri BaseAddress { get; set; }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.GetClientResponse(request);
        }

        private Task<HttpResponseMessage> GetClientResponse(HttpRequestMessage request)
        {

            HttpResponseMessage message = null;
            if (request.Method == HttpMethod.Get)
            {
                if (this.BaseAddress.PathAndQuery == "/AccountService.svc/balance?accountNumber=4001")
                {
                    var stream = this.GenerateStreamFromString("{\"AccountNumber\":\"4001\",\"Successful\":\"true\",\"Balance\":\"200\",\"Currency\":\"INR\",\"Message\":\"Balance query completed successfully.\"}");
                    message = new HttpResponseMessage()
                    {
                        Content = new StreamContent(stream),
                        ReasonPhrase = "OK",
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }
                else if (this.BaseAddress.PathAndQuery == "/AccountService.svc/balance?accountNumber=4002")
                {
                    var stream = this.GenerateStreamFromString("{\"AccountNumber\":\"4002\",\"Successful\":\"true\",\"Balance\":\"0\",\"Currency\":\"INR\",\"Message\":\"Balance query completed successfully.\"}");
                    message = new HttpResponseMessage()
                    {
                        Content = new StreamContent(stream),
                        ReasonPhrase = "OK",
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }

                else
                {
                    var stream = this.GenerateStreamFromString("{\"AccountNumber\":\"4010\",\"Successful\":\"false\",\"Balance\":\"0\",\"Currency\":\"\",\"Message\":\"Transaction failed. Invalid account number.\"}");
                    message = new HttpResponseMessage()
                    {
                        Content = new StreamContent(stream),
                        ReasonPhrase = "OK",
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }
            }
            else // To check post methods
            {
                var requestParams = request.Content.ReadAsStringAsync().Result;
                var requestJsonObject = JsonConvert.DeserializeObject<JObject>(requestParams);
                var accNo = requestJsonObject["accountNumber"].ToString();
                if (this.BaseAddress.PathAndQuery == "/AccountService.svc/deposit")
                {
                    if (accNo == "4003")
                    {
                        var stream = this.GenerateStreamFromString("{\"DepositMoneyResult\":{\"AccountNumber\":\"4003\",\"Successful\":\"true\",\"Balance\":\"300\",\"Currency\":\"INR\",\"Message\":\"Amount deposited successfully.\"}}");
                        message = new HttpResponseMessage()
                        {
                            Content = new StreamContent(stream),
                            ReasonPhrase = "OK",
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                    else
                    {
                        var stream = this.GenerateStreamFromString("{\"DepositMoneyResult\":{\"AccountNumber\":\"4011\",\"Successful\":\"false\",\"Balance\":\"0\",\"Currency\":\"\",\"Message\":\"Transaction failed. Invalid account number.\"}}");
                        message = new HttpResponseMessage()
                        {
                            Content = new StreamContent(stream),
                            ReasonPhrase = "OK",
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                }
                else if (this.BaseAddress.PathAndQuery == "/AccountService.svc/withdraw")
                {
                    if (accNo == "4004")
                    {
                        var stream = this.GenerateStreamFromString("{\"WithdrawMoneyResult\":{\"AccountNumber\":\"4004\",\"Successful\":\"true\",\"Balance\":\"200\",\"Currency\":\"INR\",\"Message\":\"Withdrawal completed successfully.\"}}");
                        message = new HttpResponseMessage()
                        {
                            Content = new StreamContent(stream),
                            ReasonPhrase = "OK",
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                    else if (accNo == "4005")
                    {
                        var stream = this.GenerateStreamFromString("{\"WithdrawMoneyResult\":{\"AccountNumber\":\"4005\",\"Successful\":\"false\",\"Balance\":\"0\",\"Currency\":\"INR\",\"Message\":\"Transaction failed. Insufficient balance.\"}}");
                        message = new HttpResponseMessage()
                        {
                            Content = new StreamContent(stream),
                            ReasonPhrase = "OK",
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                    else if (accNo == "4006")
                    {
                        var stream = this.GenerateStreamFromString("{\"WithdrawMoneyResult\":{\"AccountNumber\":\"4006\",\"Successful\":\"false\",\"Balance\":\"80\",\"Currency\":\"INR\",\"Message\":\"Transaction failed. Insufficient balance.\"}}");
                        message = new HttpResponseMessage()
                        {
                            Content = new StreamContent(stream),
                            ReasonPhrase = "OK",
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }

                    else
                    {
                        var stream = this.GenerateStreamFromString("{\"WithdrawMoneyResult\":{\"AccountNumber\":\"4012\",\"Successful\":\"false\",\"Balance\":\"0\",\"Currency\":\"\",\"Message\":\"Transaction failed. Invalid account number.\"}}");
                        message = new HttpResponseMessage()
                        {
                            Content = new StreamContent(stream),
                            ReasonPhrase = "OK",
                            StatusCode = System.Net.HttpStatusCode.OK
                        };
                    }
                }
                
            }
            return Task.FromResult(message);

        }

        private MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
