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
        //Takes in OrderId and ProductId as arguments
        public int Add(int _orderId, int _productId)
        {
            return db.Insert($"INSERT INTO OrderProduct VALUES(null, {_orderId}, {_productId})");
        }

        // return a List of all of the OrderProducts from the database 
        public List<OrderProduct> GetAllOrderProduct()
        {
            //Instantiate a blank list to add OrderProducts to
            List<OrderProduct> AllOrderProducts = new List<OrderProduct>();

            //Send SQL statement into database to return ALL from the OrderProduct table
            db.Query(
                "SELECT * FROM OrderProduct",
                (SqliteDataReader reader) =>
                {
                    //Callback function to iterate through the returned object
                    //Create a new instance of the OrderProduct class by scraping the id from column 0
                    //The OrderId from column 1 and the Product Id from Column 2
                    //Add the new OrderProduct to the list
                    while (reader.Read())
                    {
                        AllOrderProducts.Add(new OrderProduct(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
            );

            //Return the list
            return AllOrderProducts;
        }

        // return all of the OrderProducts associated with the OrderId passed into the function
        public List<OrderProduct> GetOrderProductByOrderId(int OrderId)
        {
            //Instantiate a blank list to add OrderProducts to
            List<OrderProduct> OrderProductByOrderId = new List<OrderProduct>();

            db.Query(
            //Send SQL statement into database to return OrderProduct that match the passed in OrderId
                $"SELECT * FROM OrderProduct WHERE OrderProduct.OrdersId = {OrderId}",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        //Callback function to iterate through the returned object
                        //Create a new instance of the OrderProduct class by scraping the id from column 0
                        //The OrderId from column 1 and the Product Id from Column 2
                        //Add the new OrderProduct to the list
                        OrderProductByOrderId.Add(new OrderProduct(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
            );

            //Return the list
            return OrderProductByOrderId;
        }
        public int FindProductAvailability(int ProductId)
        {
            int available = 0;

            string QueryString = $@"SELECT p.Quantity, COUNT(op.id), p.Quantity - COUNT(op.id), P.Id FROM Product P
			LEFT JOIN OrderProduct op
            ON p.Id = op.ProductId
			WHERE P.ID = {ProductId}
			GROUP BY op.ProductId";

            db.Query(
            //Send SQL statement into database to return OrderProduct that match the passed in OrderId
                QueryString,
                (SqliteDataReader reader) =>
                {
                    reader.Read();
                    available = reader.GetInt32(0);
                }
            );

            //Return the list
            return available;
        }

        //Call the db.ExecuteNonQuery method with a SQL statemnt to delete the OrderProduct with the passed in Id #
        public void DeleteOrderProduct(int OrderProductId)
        {
            db.ExecuteNonQuery($"DELETE FROM OrderProduct WHERE Id = {OrderProductId}");
        }

        //Constructor method that takes in a connection_string to create the database interface.
        //This has a default value of the Environmental variable of the production database
        //When the test database is desired you can pass in the string "BANGAZON_CLI_TEST" in as an argument
        //If no string is passed in the default value will be used
        public OrderProductManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            db = new DatabaseInterface(connection_string);
        }
    }
}