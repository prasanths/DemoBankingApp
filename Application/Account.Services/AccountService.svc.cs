using Account.Repository.Interfaces;
using Account.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Account.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.repository = accountRepository;
        }
        public RequestResult DepositMoney(int accountNumber, decimal amount, string currency)
        {
            try
            {
                var accountDetails = this.repository.Deposit(accountNumber, amount, currency);
                return new RequestResult()
                {
                    AccountNumber = accountDetails.AccountNumber,
                    Balance = accountDetails.Balance,
                    Message = "Amount deposited successfully.",
                    Currency = accountDetails.Currency,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResult()
                {
                    AccountNumber = accountNumber,
                    Balance = 0,
                    Message = "Transaction failed. " + ex.Message,
                    Currency = currency,
                    Successful = false
                };
            }
        }

        public RequestResult GetBalance(int accountNumber)
        {
            try
            {
                var accountDetails = this.repository.GetAccountBalance(accountNumber);
                return new RequestResult()
                {
                    AccountNumber = accountDetails.AccountNumber,
                    Balance = accountDetails.Balance,
                    Message = "Balance query completed successfully.",
                    Currency = accountDetails.Currency,
                    Successful = true
                };
            }
            catch(Exception ex)
            {
                return new RequestResult()
                {
                    AccountNumber = accountNumber,
                    Balance = 0,
                    Message = "Transaction failed. " + ex.Message,
                    Successful = false
                };
            }
        }

        public RequestResult WithdrawMoney(int accountNumber, decimal amount, string currency)
        {
            try
            {
                var accountDetails = this.repository.Withdraw(accountNumber, amount, currency);
                return new RequestResult()
                {
                    AccountNumber = accountDetails.AccountNumber,
                    Balance = accountDetails.Balance,
                    Message = "Withdrawal completed successfully.",
                    Currency = accountDetails.Currency,
                    Successful = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResult()
                {
                    AccountNumber = accountNumber,
                    Message = "Transaction failed. " + ex.Message,
                    Successful = false
                };
            }
}
    }
}
