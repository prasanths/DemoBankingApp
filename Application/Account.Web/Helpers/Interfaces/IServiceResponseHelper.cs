using Account.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Account.Web.Helpers.Interfaces
{
    public interface IServiceResponseHelper
    {
        Task<ServiceResponseModel> GetResponse(string url, HttpMethod method, IDictionary<string, string> dictionaryContent, string mediaType, Encoding encoding);
    }
}