//Author: Chris Miller
 //Purpose: Class to execute the query to return the stale products

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;
using BangazonCLI.Data;

namespace BangazonCLI.Managers
{
    public class StaleProductManager
    {
        private DatabaseInterface db;

        public List<StaleProductViewModel> GetStaleProducts()
        {

            //This is 3 seperate queries that are unioned together to return the products that meet the requirements
            //then joined with other tables to gather the rest of the info

            string QueryString = @"		
            SELECT DISTINCT stale.Title, c.Name, stale.Quantity,  stale.Quantity - COUNT(op.ProductId) FROM
                    /*REQ 1 - Find products that have not been added to an order,
                    and have been in the system for more than 180 days*/
                    (SELECT p.* from Product p
                    Where p.Id NOT IN (SELECT DISTINCT ProductId FROM OrderProduct) 
                    AND julianday('now') - julianday(p.DateAdded) > 180
                    
                UNION
                
                    /*REQ 2 - Find products that have been added to the orders but not purchased
                    and the orders are more than 90 days old*/
                    SELECT p.* FROM
                    (SELECT  DISTINCT ProductId FROM OrderProduct op
                    JOIN Orders o ON op.OrdersId = o.Id
                    WHERE o.Closed is null and (julianday('now') - julianday(o.created)) > 90)
                    JOIN Product p
                    ON ProductId = p.Id
                    WHERE ProductId NOT IN 
                    (SELECT DISTINCT ProductId FROM OrderProduct op
                    JOIN Orders o ON op.OrdersId = o.Id
                    WHERE o.Closed is not null)
                    
                    
                UNION
                    /*REQ 3 - Find products that have been purchased, but there is remaining quantity in the system
                    and the product has been in the system for more than 180 days*/
                    
                    SELECT DISTINCT p.* FROM OrderProduct op
                    JOIN Orders o ON op.OrdersId = o.Id
                    JOIN Product p  ON op.ProductID = p.Id
                    JOIN 
                    (SELECT ProductId, COUNT(*) as Total FROM OrderProduct
                    WHERE OrdersId in
                    (SELECT Id FROM Orders
                    WHERE Closed is not null)
                    GROUP BY ProductId) total_sold
                    ON p.Id = total_sold.ProductId
                    WHERE o.Closed is not null
                    AND julianday('now') - julianday(p.DateAdded) > 180
                    AND p.Quantity > total_sold.Total) stale
            JOIN Customer c
            ON CustomerId = c.Id
			LEFT JOIN OrderProduct op
            ON stale.Id = op.ProductId
			GROUP BY op.ProductId
            ";

            //Intantiate a list to hold the stale products
            List<StaleProductViewModel> StaleProductList = new List<StaleProductViewModel>();

            //Execute the query string
            db.Query(QueryString, (SqliteDataReader reader) => 
            {
                while(reader.Read())
                {
                    //for each row in the result create an instance of the ViewModel and Add it to the list
                    StaleProductViewModel p = new StaleProductViewModel(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                    StaleProductList.Add(p);
                }
            });

            //Return the list of stale products
            return StaleProductList;
        }


        //Constructor method that takes in a connection_string to create the database interface.
        //This has a default value of the Environmental variable of the production database
        //When the test database is desired you can pass in the string "BANGAZON_CLI_TEST" in as an argument
        //If no string is passed in the default value will be used
        public StaleProductManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            db = new DatabaseInterface(connection_string);
        }
    }
}