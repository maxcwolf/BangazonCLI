//Chris Miller
//OrderProduct Manager

using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Data;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    public class OrderProductManager
    {
        private DatabaseInterface db;

        //Adds an entry to the OrderProduct Table in the database
        public int Add(int _orderId, int _productId)
        {
            return db.Insert($"INSERT INTO OrderProduct VALUES(null, {_orderId}, {_productId})");
        }

        // return all of the OrderProducts from the database 
        public List<OrderProduct> GetAllOrderProduct()
        {
            List<OrderProduct> AllOrderProducts = new List<OrderProduct>();

            db.Query(
                "SELECT * FROM OrderProduct",
                (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            AllOrderProducts.Add(new OrderProduct( reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                        }
                    }
            );

            return AllOrderProducts;
        }

        // return all of the OrderProducts associated with the OrderId passed into the function
        public List<OrderProduct> GetOrderProductByOrderId(int OrderId)
        {
            List<OrderProduct> OrderProductByOrderId = new List<OrderProduct>();

            db.Query(
                $"SELECT * FROM OrderProduct WHERE OrderProduct.OrdersId = {OrderId}",
                (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            OrderProductByOrderId.Add(new OrderProduct( reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                        }
                    }
            );

            return OrderProductByOrderId;
        }

        public void DeleteOrderProduct(int OrderProductId)
        {
            db.Delete($"DELETE FROM OrderProduct WHERE Id = {OrderProductId}");
        }

        public OrderProductManager(string connection_string = "BANGAZON_CLI")
        {
            db = new DatabaseInterface(connection_string);
        }
    }
}