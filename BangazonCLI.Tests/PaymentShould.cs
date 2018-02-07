//Author: Paul Ellis; Purpose: Test Payment class assocaited methods

using System;
using Xunit;
using BangazonCLI;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using System.Collections.Generic;

namespace BangazonCLI.Tests
{
    public class PaymentShould
    {
        //Create a new instance of the PaymentManager with list for payments and methods
        private PaymentManager _TestPaymentManager = new PaymentManager();
        //Create a Payment for testings
        private Payment _TestPayment = new Payment(1, "Visa", "9999999999999999", 1);
        [Fact]
        public void CreatePayment()
        {
            //_TestPayment.PaymentType should have the value of "Visa"
            Assert.Equal("Visa", _TestPayment.PaymentType);
        }

        [Fact]
        public void SeedPaymentDB()
        {
            //When the test payment is passed to the AddPayment method 
            _TestPaymentManager.Add(_TestPayment);
            //The payment should be contained in the list of payments returned by GetAllPayments
            Assert.Contains(_TestPayment, _TestPaymentManager.GetAllPayments());
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
