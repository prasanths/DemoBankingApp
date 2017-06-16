using Account.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Account.Services
{
    /// <summary>
    /// ServiceContract for AccountService
    /// </summary>
    [ServiceContract]
    public interface IAccountService
    {
        /// <summary>
        /// OperationContract to get account balance.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "balance?accountNumber={accountNumber}")]
        [OperationContract]
        RequestResult GetBalance(int accountNumber);

        /// <summary>
        /// OperationContract to withdraw money from an active account.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "withdraw")]
        [OperationContract]
        RequestResult WithdrawMoney(int accountNumber, decimal amount, string currency);

        /// <summary>
        /// OperationContract to deposit money to an active account.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "deposit")]
        [OperationContract]
        RequestResult DepositMoney(int accountNumber, decimal amount, string currency);
    }
}
