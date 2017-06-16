using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Account.Web.Models
{
    public class RequestResultModel
    {
        public string AccountNumber { get; set; }

        public bool Successful { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }

        public string Message { get; set; }
    }
}