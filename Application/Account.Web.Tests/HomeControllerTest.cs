using Account.Web.Controllers;
using Account.Web.Enums;
using Account.Web.Helpers.Interfaces;
using Account.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace Account.Web.Tests
{
    /// <summary>
    /// Test class to test HomeController actions
    /// </summary>
    public class HomeControllerTest: IClassFixture<BootStrapper>
    {
        private readonly IServiceResponseHelper serviceResponseHelper;
        private readonly HomeController homeController;

        public HomeControllerTest(BootStrapper bootStrapper)
        {
            this.serviceResponseHelper = bootStrapper.Container.GetInstance<IServiceResponseHelper>();
            homeController = new HomeController(this.serviceResponseHelper);
        }

        [Fact]
        public void Can_Get_Transact_View()
        {
            // Act
            var result = this.homeController.Transact() as ViewResult;
            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.True(((AccountViewModel)result.Model).Result == null);
            Assert.True(((AccountViewModel)result.Model).TransactionTypes.Count() > 0);
        }

        [Theory]
        [InlineData(TransactionType.Balance,4001,0, "",200, true)] // Account with balance
        [InlineData(TransactionType.Balance, 4002, 0, "",0, true)] // Account with zero balance
        [InlineData(TransactionType.Deposit, 4003, 100, "INR",300, true)] // Deposit money
        [InlineData(TransactionType.Withdraw, 4004, 100, "INR",200, true)] // Withdraw money from account with cash
        [InlineData(TransactionType.Withdraw, 4005, 100, "INR",0, false)] // Withdraw money from zero balance account
        [InlineData(TransactionType.Withdraw, 4006, 100, "INR",80,  false)] // Withdraw money from account with amount less than actual amount
        [InlineData(TransactionType.Balance, 4010, 100, "INR", 0, false)] // Invalid account number.
        [InlineData(TransactionType.Deposit, 4011, 100, "INR", 0, false)] // Invalid account number.
        [InlineData(TransactionType.Withdraw, 4012, 100, "INR", 0, false)] // Invalid account number.
        public void Can_Post_To_Transact_View(TransactionType transactionType, int accountNumber, decimal amount, string currency, decimal expectedBalance, bool expectedSuccessStatus)
        {
            // Arrange

            var model = new AccountViewModel()
            {
                TransactionType = transactionType,
                AccountNumber = accountNumber,
                TransactionAmount = amount,
                Currency = currency
            };

            // Act
            var result = this.homeController.Transact(model).Result as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.NotNull(((AccountViewModel)result.Model).Result);
            Assert.Equal(expectedBalance, ((AccountViewModel)result.Model).Result.Balance);
            Assert.Equal(expectedSuccessStatus, ((AccountViewModel)result.Model).Result.Successful);
        }
    }
}
