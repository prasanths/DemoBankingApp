using Account.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Repository;
using Account.Services.Entities;
using Account.CustomExceptions;

namespace Account.Services.Tests.Repository
{
    public class FakeAccountRepository : IAccountRepository
    {
        public Account.Repository.Account Deposit(int accountNumber, decimal amount, string currency)
        {
            Account.Repository.Account account = null;
            if (accountNumber == 4001)
            {
                account = new Account.Repository.Account()
                {
                    AccountNumber = 4001,
                    Balance = 300,
                    Currency = "INR",
                    AccountId = 1,
                    AccountStatusId = 1,
                    BranchId = 1,
                    CustomerId = 1,
                    StartDate = new DateTime(2017, 5, 1)
                };
            }
            else if (accountNumber == 4006)
            {
                throw new InvalidCurrencyException("Invalid currency type.");
            }
            else
            {
                throw new InvalidAccountException("Invalid account number.");
            }
            return account;
        }

        public Account.Repository.Account GetAccountBalance(int accountNumber)
        {
            Account.Repository.Account account = null;
            if (accountNumber == 4000)
            {
                account = new Account.Repository.Account()
                {
                    AccountNumber = 4000,
                    Balance = 200,
                    Currency = "INR",
                    AccountId = 1,
                    AccountStatusId = 1,
                    BranchId = 1,
                    CustomerId = 1,
                    StartDate = new DateTime(2017, 5, 1)
                };
            }

            return account;
        }

        public Account.Repository.Account Withdraw(int accountNumber, decimal amount, string currency)
        {
            Account.Repository.Account account = null;
            if (accountNumber == 4002)
            {
                account = new Account.Repository.Account()
                {
                    AccountNumber = 4002,
                    Balance = 200,
                    Currency = "INR",
                    AccountId = 1,
                    AccountStatusId = 1,
                    BranchId = 1,
                    CustomerId = 1,
                    StartDate = new DateTime(2017, 5, 1)
                };
            }
            else if (accountNumber == 4003 || accountNumber == 4004)
            {
                throw new InsufficientBalanceException("Insufficient balance.");
            }
            else if(accountNumber == 4005)
            {
                throw new InvalidCurrencyException("Invalid currency type.");
            }
            else
            {
                throw new InvalidAccountException("Invalid account number.");
            }
            return account;
        }
    }
}
