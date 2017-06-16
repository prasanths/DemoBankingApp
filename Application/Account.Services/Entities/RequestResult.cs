using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Account.Services.Entities
{
    [DataContract]
    public class RequestResult
    {
        //TODO: change to int
        [DataMember]
        public int AccountNumber { get; set; }

        [DataMember]
        public bool Successful { get; set; }

        [DataMember]
        public decimal Balance { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}