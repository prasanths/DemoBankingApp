using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccountBalance(int accountNumber);
        Account Deposit(int accountNumber, decimal amount, string currency);
        Account Withdraw(int accountNumber, decimal amount, string currency);
    }
}
