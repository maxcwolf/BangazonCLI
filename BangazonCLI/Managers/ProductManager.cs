//Author: Ray Medrano //Purpose: This Class handles all operations dealing with products
using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;
using BangazonCLI.Data;

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        DatabaseInterface db = new DatabaseInterface();
        //public List<Product> ProductList =  new List<Product>();

        //This method adds a product to the database with the following arguments
        // NewProduct
        public int AddProduct(int _customerId, string _title, string _description, int _price,int _quantity)
        {
            //create a datetime for order added
            DateTime _dateAdded = DateTime.Now;
            return db.Insert($"INSERT INTO Product VALUES (null, {_customerId}, {_title}, {_description}, {_price}, {_quantity}, {_dateAdded}");
        }

        //This method returns a list of products from the database for the active customer with the follwing argument
        // id = the customer id
        public List<Product> GetCustomerProducts(int id)
        {
            //create a list to hold products fromt the database
            List<Product> productlist = new List<Product>();
            //create query to send to database
            string newquery =
                            $@"SELECT  id ,CustomerId, Title, Description, Price, Quantity, DateAdded
                            FROM Product
                            WHERE CustomerId = {id}";
            //return a list of products where CustomerId = id
            db.Query(newquery, (SqliteDataReader handler) =>
               {
                   while (handler.Read())
                   {
                       productlist.Add(new Product(handler.GetInt32(0), handler.GetInt32(1), handler.GetString(2), handler.GetString(3),handler.GetInt32(4), handler.GetInt32(5), handler.GetDateTime(6)));
                   }
               });
               return productlist;
        }

        //this method returns a list of products from the database where the customer id is not equal to the active user it accepts the following argument
        // activeCustomerId = the id of the current active customer

        public List<Product> GetNonActiveUserProduct(int activeCustomerId)
        {
            //create database query string using the active customer id
            string NonActiveCustomerProductQuery =
                            $@"SELECT  id ,CustomerId, Title, Description, Price, Quantity, DateAdded
                            FROM Product
                            WHERE CustomerId != {activeCustomerId}";
            //create a list to hold products fromt the database
            List<Product> productlist = new List<Product>();

            //exectute database query and return product list
            db.Query(NonActiveCustomerProductQuery, (SqliteDataReader handler) =>
               {
                   while (handler.Read())
                   {
                       productlist.Add(new Product(handler.GetInt32(0), handler.GetInt32(1), handler.GetString(2), handler.GetString(3),handler.GetInt32(4), handler.GetInt32(5), handler.GetDateTime(6)));
                   }
               });
               return productlist;
        }

        //Constructor method that takes in a connection_string to create the database interface.
        //This has a default value of the Environmental variable of the production database
        //When the test database is desired you can pass in the string "BANGAZON_CLI_TEST" in as an argument
        //If no string is passed in the default value will be used
        public ProductManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            db = new DatabaseInterface(connection_string);
        }
    }
}