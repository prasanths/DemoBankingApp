using Account.CustomExceptions;
using Account.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Repository
{
    /// <summary>
    /// Repository class for accont related data operations
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// Method for depositing money
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Account Deposit(int accountNumber, decimal amount, string currency)
        {
            using (var context = new BankDBEntities())
            {
                // Get Account Details 
                var account = context.Account.SingleOrDefault(x => x.AccountNumber == accountNumber && x.AccountStatus.StatusCode == Enums.AccountStatus.Active.ToString());
                if(account == null)
                {
                    throw new InvalidAccountException("Invalid account number.");
                }
                // Check for invalid currency
                if (account.Currency != currency)
                {
                    throw new InvalidCurrencyException("Invalid currency type.");
                }
                // Get TransactionType to create Transaction table entry
                var transactionType = context.TransactionType.SingleOrDefault(x => x.TypeCode == Enums.TransactionType.Deposit.ToString());

                // Create an entry in Transaction table
                var transaction = context.Transaction.Add(new Transaction()
                {
                    AccountId=account.AccountId,
                    Amount = amount,
                    TransactionDate=DateTime.Now,
                    TransactionTypeId = transactionType.TypeId

                });

                account.Balance = account.Balance + amount;
                account.Currency = currency;
                context.SaveChanges();
                if(transaction.TransactionId > 0)
                {
                    return account;
                }
                else
                {
                    throw new TransactionException("Transaction failed.");
                }
            }
        }

        /// <summary>
        /// Method for getting account balance
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public Account GetAccountBalance(int accountNumber)
        {
            using (var context = new BankDBEntities())
            {
                // Get Account Details
                var account = context.Account.SingleOrDefault(x => x.AccountNumber == accountNumber && x.AccountStatus.StatusCode == Enums.AccountStatus.Active.ToString());
                if (account == null)
                {
                    throw new InvalidAccountException("Invalid account number.");
                }
                return account;
            }
        }

        /// <summary>
        /// Method for withdrawing money
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Account Withdraw(int accountNumber, decimal amount, string currency)
        {
            using (var context = new BankDBEntities())
            {
                // Get Account Details
                var account = context.Account.SingleOrDefault(x => x.AccountNumber == accountNumber && x.AccountStatus.StatusCode == Enums.AccountStatus.Active.ToString());
                if (account == null)
                {
                    throw new InvalidAccountException("Invalid account number.");
                }
                if (account.Currency != currency)
                {
                    throw new InvalidCurrencyException("Invalid currency type.");
                }
                var transactionType = context.TransactionType.SingleOrDefault(x => x.TypeCode == Enums.TransactionType.Withdraw.ToString());

                if (account.Balance > 0 && account.Balance > amount)
                {

                    var transaction = context.Transaction.Add(new Transaction()
                    {
                        AccountId = account.AccountId,
                        Amount = amount,
                        TransactionDate = DateTime.Now,
                        TransactionTypeId = transactionType.TypeId

                    });

                    account.Balance = account.Balance - amount;
                    account.Currency = currency;
                    context.SaveChanges();
                    if (transaction.TransactionId > 0)
                    {
                        return account;
                    }
                    else
                    {
                        throw new TransactionException("Transaction failed.");
                    }
                }
                else
                {
                    throw new InsufficientBalanceException("Insufficient balance.");
                }
            }
        }
    }
}
