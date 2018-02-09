//Author: Chase Steely
//Purpose: To manage the Orders Table.
using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Data;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    public class OrdersManager
    {
        public List<Orders> OrdersList = new List<Orders>();
        private List<Payment> _PaymentOptions = new List<Payment>();
        public DatabaseInterface _db;

        //This method returns the Active Order or creates an Order if there isn't an active Order.
        // id = the customer id
        public int GetActiveOrder(int ActiveCustomerId)
        {
            //return active order, if there isn't one create an Order
            try
            {
                return OrdersList.Where(o => o.CustomerId == ActiveCustomerId && o.PaymentId == null).Single().Id;
            }
            catch
            {
                DateTime now = DateTime.Now;
                int id = _db.Insert($"INSERT INTO [Orders] VALUES (null, {ActiveCustomerId}, null, {now} )");
                Console.WriteLine("Order Created.");
                return id;
            }
        }

        public int CheckCart(int OrderId)
        {
            OrderProductManager opm = new OrderProductManager();
            if (opm.GetOrderProductByOrderId(OrderId).Count == 0)
            {
                return 0;
            }
            return 1;
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
        //  Add a payment to the null field "payment" in an order, return true once complete
        public bool AddPayment(int payId)
        {
            _db.Insert($"UPDATE [Orders] SET paymentId = {payId} WHERE [Orders].Id = {Id}");
            return true;
        }
    }
}