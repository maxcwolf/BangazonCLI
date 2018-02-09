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
        //Test database path passed into the method will create connection string with test db file
        private PaymentManager _TestPaymentManager = new PaymentManager("BANGAZON_CLI_TEST");

        //Test to method that adds a new payment to the data base
        [Fact]
        public void SeedPaymentDB()
        {
            /*variable holds return value of customerId from the created payment.  Add method accepts customer id,
            Name of the payment type, and the account number.*/
            int returnNum = _TestPaymentManager.Add(1, "Visa", "TestAccountNumber");
            //call the GetCustomerPayments method, passing in the customer id of 1
            List<Payment> results = _TestPaymentManager.GetCustomerPayments(1);
            //filter out the result that matches the account number data passed into the Add method above
            Payment result = results.Find(p=> p.AccountNumber == "TestAccountNumber");
            //Given the data creation above, assert that the result will have account number matching that passed to Add()
            Assert.Equal("TestAccountNumber", result.AccountNumber);
        }

        [Fact]
        public void GetCustomerPayments()
        {
            //After passing a customer id to the GetCustomerPayments method
            List<Payment> CustomerPayments = _TestPaymentManager.GetCustomerPayments(1);

            //Each payment in the returned list should have a customer id that matches what was passed in
            CustomerPayments.ForEach(p => Assert.Equal(1, p.CustomerId));
       }

       
}
}
