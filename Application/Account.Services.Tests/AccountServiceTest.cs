using Account.CustomExceptions;
using Account.Repository.Interfaces;
using Account.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Account.Services.Tests
{
    public class AccountServiceTest : IClassFixture<BootStrapper>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountService accountService;
        public AccountServiceTest(BootStrapper bootStrapper)
        {
            this.accountRepository = bootStrapper.Container.GetInstance<IAccountRepository>();
            this.accountService = bootStrapper.Container.GetInstance<IAccountService>();
        }

        [Theory]
        [InlineData(4000, 200)] // Existing account
        [InlineData(4005, 0)] // Non-existing account
        public void Can_Check_Balance(int accountNumber, int exptectedAccBalance)
        {
            // Arrange

            // Act
            var requestResult = this.accountService.GetBalance(accountNumber);

            // Assert
            Assert.NotNull(requestResult);
            Assert.Equal(exptectedAccBalance, requestResult.Balance);

        }

        [Theory]
        [InlineData(4001, 300, "INR", 300)]
        [InlineData(4006, 100, "USD", 0)] // Invalid currency
        [InlineData(4010, 100, "INR", 0)] // Invalid account number
        public void Can_Deposit_Money(int accountNumber, decimal amount, string currency, int exptectedAccBalance)
        {
            // Act
            var requestResult = this.accountService.DepositMoney(accountNumber,amount,currency);

            // Assert
            Assert.NotNull(requestResult);
            if (accountNumber == 4010)
            {
                Assert.Equal(requestResult.Message, "Transaction failed. Invalid account number.");
            }
            else if (accountNumber == 4006)
            {
                Assert.Equal(requestResult.Message, "Transaction failed. Invalid currency type.");
            }
            else
            {
                Assert.Equal(exptectedAccBalance, requestResult.Balance);
            }
        }

        [Theory]
        [InlineData(4002, 100, "INR", 200)] // Account with balance greater than withdrawal amount
        [InlineData(4003, 100, "INR", 0)] // Account with zero balance
        [InlineData(4004, 100, "INR", 70)] // Account with balance less than withdrawal amount
        [InlineData(4005, 100, "USD", 0)] // Invalid currency
        [InlineData(4010, 100, "INR", 0)] // Invalid account number
        public void Can_Withdraw_Money(int accountNumber, decimal amount, string currency, int exptectedAccBalance)
        {
            // Arrange 

            // Act
            var requestResult = this.accountService.WithdrawMoney(accountNumber, amount, currency);

            // Assert

            Assert.NotNull(requestResult);
            if (accountNumber == 4010) 
            {
                Assert.Equal(requestResult.Message, "Transaction failed. Invalid account number.");
            }
            else if (accountNumber == 4005)
            {
                Assert.Equal(requestResult.Message, "Transaction failed. Invalid currency type.");
            }
            else if (amount > exptectedAccBalance)
            {
                Assert.Equal(requestResult.Message, "Transaction failed. Insufficient balance.");
            }
            else
            {
                Assert.Equal(exptectedAccBalance, requestResult.Balance);
            }
        }
    }
}
