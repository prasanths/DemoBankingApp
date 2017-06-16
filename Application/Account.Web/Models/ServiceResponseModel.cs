using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Account.Web.Models
{
    public class ServiceResponseModel
    { 
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the response phrase.
        /// </summary>
        public string ResponsePhrase { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the status code is success.
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }
    }
}