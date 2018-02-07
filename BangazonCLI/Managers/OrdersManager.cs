//Author: Chase Steely
//Purpose: To manage the Orders Table.
using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class OrdersManager
    {
        public List<Orders> OrdersList = new List<Orders>();

        //This method adds a order to the database with the following arguments
        // NewOrder  = The default order object (see the constructor on the order class)
        public void AddOrder(Orders NewOrder)
        {
            //add order to order list
            OrdersList.Add(NewOrder);
        }

        //This method returns a list of orders from the database for the active customer with the follwing argument
        // id = the customer id
        public Orders GetCustomerOrders(int id)
        {
            //return a list of orders where CustomerId = id
            return OrdersList.Where(o => o.CustomerId == id && o.PaymentId == null).Single();
        }

        //This method gets an Order that has not been completed; assigns a paymentId, and a Close date.
        public void CompleteOrder(int id, int paymentId)
        {
            Orders ThisOrder = OrdersList.Where(o => o.CustomerId == id && o.PaymentId == null).Single();
            ThisOrder.PaymentId = paymentId;
            ThisOrder.Closed = DateTime.Now;
        }
        //This method  returns a single order by Order Id.
        public Orders GetOrderByOrderId(int id)
        {
            return OrdersList.Where(o => o.Id == id).Single();
        }
    }
}