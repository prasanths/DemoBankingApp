using Account.Web.Enums;
using Account.Web.Helpers;
using Account.Web.Helpers.Interfaces;
using Account.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Account.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string serviceBaseUrl;

        private readonly IServiceResponseHelper serviceResponseHelper;

        public HomeController(IServiceResponseHelper responseHelper)
        {

            this.serviceBaseUrl = ConfigurationManager.AppSettings["AccountServiceEndPoint"].ToString();
            this.serviceResponseHelper = responseHelper;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Transact()
        {
            var viewModel = new AccountViewModel();

            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Transact(AccountViewModel viewModel)
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            switch (viewModel.TransactionType)
            {
                case TransactionType.Balance:
                    {
                        string url = serviceBaseUrl + "/balance";
                        request.Add("accountNumber", viewModel.AccountNumber.ToString());
                        var response = await this.serviceResponseHelper.GetResponse(url, HttpMethod.Get, request, null, System.Text.Encoding.UTF8);
                        var responseModel = JsonConvert.DeserializeObject<RequestResultModel>(response.Content);
                        viewModel.Result = responseModel;


                        break;
                    }
                case TransactionType.Deposit:
                    {
                        string url = serviceBaseUrl + "/deposit";
                        request.Add("accountNumber", viewModel.AccountNumber.ToString());
                        request.Add("amount", viewModel.TransactionAmount.ToString());
                        request.Add("currency", viewModel.Currency);
                        var response = await this.serviceResponseHelper.GetResponse(url, HttpMethod.Post, request, "application/json", System.Text.Encoding.UTF8);
                        var responseModel = JsonConvert.DeserializeObject<JObject>(response.Content);
                        var result = responseModel["DepositMoneyResult"].ToObject<RequestResultModel>();
                        viewModel.Result = result;

                        break;
                    }
                case TransactionType.Withdraw:
                    {
                        string url = serviceBaseUrl + "/withdraw";
                        request.Add("accountNumber", viewModel.AccountNumber.ToString());
                        request.Add("amount", viewModel.TransactionAmount.ToString());
                        request.Add("currency", viewModel.Currency);
                        var response = await this.serviceResponseHelper.GetResponse(url, HttpMethod.Post, request, "application/json", System.Text.Encoding.UTF8);
                        var responseModel = JsonConvert.DeserializeObject<JObject>(response.Content);
                        var result = responseModel["WithdrawMoneyResult"].ToObject<RequestResultModel>(); 
                        viewModel.Result = result;
                        break;
                    }

            }
            return View(viewModel);
        }
    }
}