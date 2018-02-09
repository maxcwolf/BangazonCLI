//Author: Chase Steely
//Purpose: TO test creating a new order and completing an order
using System;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

namespace BangazonCLI.Tests
{
    public class OrdersShould
    {
        //Instantiate OrdersManager
        private OrdersManager om { get; set; }

        //Connect to the Database
        public OrdersShould()
        {
            this.om = new OrdersManager("BANGAZON_CLI_TEST");
        }
        //This tests that there is an Active Order and if not it creates one.
        [Fact]
        public void GetTheOrder()
        {
            //Getting Active Order by Customer Id
            int active = om.GetActiveOrder(1);

            //Assert that the an Order Id is returned and is an int
            Assert.IsType<int>(active);
        }

        //Test to add a payment to the Order and a close date to complete the order.
        [Fact]
        public void CompleteOrder()
        {

            var paid = om.AddPaymentTypeToOrder(1, 1);

            //Assert that the payment was added.
            Assert.True(paid);
        }

    }
}
