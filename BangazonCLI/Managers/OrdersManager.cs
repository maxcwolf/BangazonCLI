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
        private DatabaseInterface _db;

        //This method returns the Active Order or creates an Order if there isn't an active Order.
        public int GetActiveOrder(int ActiveCustomerId)
        {
            //return active order, if there isn't one moves to the catch: create an Order
            try
            {
                int oId = 0;
                _db.Query($"SELECT Id FROM Orders WHERE CustomerId = {ActiveCustomerId} AND PaymentId IS NULL", (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        oId = reader.GetInt32(0);
                    }
                }
           );
                return oId;
            }
            catch
            {
                DateTime now = DateTime.Now;
                int id = _db.Insert($"INSERT INTO Orders VALUES (null, {ActiveCustomerId}, null, '{now}', null )");
                Console.WriteLine("Order Created.");
                return id;
            }
        }
        //Checks to see if Customer has Products in their Active Order
        public int CheckCart(int OrderId)
        {
            OrderProductManager opm = new OrderProductManager();
            if (opm.GetOrderProductByOrderId(OrderId).Count == 0)
            {
                return 0;
            }
            return 1;
        }

        //This method  returns a single order by Order Id.
        public Orders GetOrderByOrderId(int id)
        {
            return OrdersList.Where(o => o.Id == id).Single();
        }
        //This method gets Active Order; assigns a paymentId, and a Close date.
        public bool AddPaymentTypeToOrder(int payId, int orderId)
        {
            DateTime now = DateTime.Now;
            _db.Insert($"UPDATE Orders SET PaymentId = {payId}, Closed = '{now}' WHERE Orders.Id = {orderId}");
            return true;
        }
        //Connecting to Environmental Variable
        public OrdersManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            _db = new DatabaseInterface(connection_string);
        }
    }
}