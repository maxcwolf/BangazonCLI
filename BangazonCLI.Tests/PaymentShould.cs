//Author: Paul Ellis; Purpose: Test Payment class assocaited methods

using System;
using Xunit;
using BangazonCLI;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using System.Collections.Generic;
using BangazonCLI.Data;

namespace BangazonCLI.Tests
{
    public class PaymentShould
    {
        //Create a new instance of the PaymentManager with list for payments and methods
        private PaymentManager _TestPaymentManager = new PaymentManager("BANGAZON_CLI_TEST");
        //Create a Payment for testings


        [Fact]
        public void SeedPaymentDB()
        {
            int returnNum = _TestPaymentManager.Add(1, "Visa", "TestAccountNumber");
            List<Payment> results = _TestPaymentManager.GetCustomerPayments(1);
            Payment result = results.Find(p=> p.AccountNumber == "TestAccountNumber");
            Assert.Equal("TestAccountNumber", result.AccountNumber);
        }

    //     [Fact]
    //     public void GetCustomerPayments()
    //     {
    //         //After passing a customer id to the GetCustomerPayments method
    //         List<Payment> CustomerPayments = _TestPaymentManager.GetCustomerPayments(1);

    //         //Each payment in the returned list should have a customer id that matches what was passed in
    //         CustomerPayments.ForEach(p => Assert.Equal(1, p.CustomerId));
    //    }

       
}
}
