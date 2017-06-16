using Account.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Account.Web.Models
{
    public class AccountViewModel
    {
        public int AccountNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Currency { get; set; }
        public IList<string> TransactionTypes
        {
            get
            {
                return Enum.GetNames(typeof(TransactionType));
            }
        }
        //public CustomerAccountViewModel CustomerAccount { get; set; }
        public RequestResultModel Result { get; set; }

    }
}