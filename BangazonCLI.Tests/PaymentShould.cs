//Author: Paul Ellis; Purpose: Test Payment class assocaited methods

using System;
using Xunit;
using BangazonCLI;
using BangazonCLI.Models;

namespace BangazonCLI.Tests
{
   public class PaymentShould
   {
       [Fact]
       public void AddPayment()
       {
           //given the following constructor for a payment type

            Payment _TestPayment = new Payment(1, "Visa", "9999999999999999", 1);

            //_TestPayment.PaymentType should have the value of "Visa"
            Assert.Equal(_TestPayment.PaymentType, "Visa");
       }
   }
}
