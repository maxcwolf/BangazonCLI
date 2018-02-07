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

        [Fact]
        public void CreateOrder()
        {
            //create instances of both the OrdersManager and a new order
            OrdersManager om = new OrdersManager();

            Orders NewOrder = new Orders();

            //Use the AddOrder method to add a new order
            om.AddOrder(NewOrder);

            //Assert that the Orders List contains the new order that was added
            Assert.Equal(NewOrder, om.GetCustomerOrders(1));
        }

        [Fact]
        public void CompleteOrder()
        {
            //create instances of both the OrdersManager and a new order
            OrdersManager om = new OrdersManager();

            Orders NewOrder = new Orders();

            //Use the AddOrder method to add a new order
            om.AddOrder(NewOrder);

            //pick the order we want to complete
            Orders OrderToComplete = om.GetCustomerOrders(1);

            //Assert that the order we want to complete has the id of 1
            om.CompleteOrder(OrderToComplete.Id, 1);

             //Assert that the paymentId of the Order we wan to complete is 1
            Assert.Equal(1, om.GetOrderByOrderId(1).PaymentId);
            //Assert that there is now a date in the Closed date field.
            Assert.NotNull(om.GetOrderByOrderId(1).Closed);
        }

    }
}
