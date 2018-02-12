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
       private DatabaseInterface db;

        //Constructor method that takes in a connection_string to create the database interface.
        //This has a default value of the Environmental variable of the production database
        //When the test database is desired you can pass in the string "BANGAZON_CLI_TEST" in as an argument
        //If no string is passed in the default value will be used
        public ProductManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            db = new DatabaseInterface(connection_string);
        }
        //This method adds a product to the database with the following arguments
        // NewProduct
        public int AddProduct(int _customerId, string _title, string _description, int _price,int _quantity)
        {
            //create a datetime for order added
            DateTime _dateAdded = DateTime.Now;
            return db.Insert($"INSERT INTO Product VALUES (null, '{_customerId}', '{_title}', '{_description}', '{_price}', '{_quantity}',Date('Now'))");
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
                       productlist.Add(new Product(handler.GetInt32(0), handler.GetInt32(1), handler.GetString(2), handler.GetString(3),handler.GetInt32(4), handler.GetInt32(5), handler.GetString(6)));
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
                       productlist.Add(new Product(handler.GetInt32(0), handler.GetInt32(1), handler.GetString(2), handler.GetString(3),handler.GetInt32(4), handler.GetInt32(5), handler.GetString(6)));
                   }
               });
               return productlist;
        }

        //This method checks the orderprodut table to see if it contains any instances of a product
        public int CheckForProductOnOrder(int _productId)
        {
            int CountTotal = 0;
            // create query string using productId
            string ProductOrderQuery =
                        $@"SELECT Count(*) as orderAmt
                        FROM OrderProduct
                        WHERE ProductId = '{_productId}'";

            db.Query(ProductOrderQuery, (SqliteDataReader handler) =>
            {
                while (handler.Read())
                {
                 //read the amount returned from the database as "orderAmt"
                 CountTotal = Convert.ToInt32(handler["orderAmt"]);
                }
            });
                return CountTotal;
        }
        //This method will delete a customer product it takes the argument of _productId, it checks if the product
        //id exists in the order product table first, if it does not it will delete otherwise it will print out a
        //warning to the customer
        //_productId = an integer refering to the product Id

        public void DeleteCustomerProduct(int _productId)
        {
            //check if product exists on the order product table
            int CountTotal = CheckForProductOnOrder(_productId);

            //if the value returned is > 0, do not delete, console writeline an error message

            if (CountTotal > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Sorry, that product exists in customer orders and cannot be deleted.");
                Console.WriteLine("Please pick another product");
                Console.WriteLine();

            }
            else
            {
                //create nonQueryString to delete product from database
                string nonQueryString =
                        $@"DELETE
                        FROM Product
                        Where Id = '{_productId}'";
                //send nonQueryString to the database
                db.ExecuteNonQuery(nonQueryString);

                //send confirmation message to the terminal
                Console.WriteLine();
                Console.WriteLine("The Product has been successfully deleted");
            }
        }

        //This method will return a single product when it is passed the product Id.
        //_productId = int, id of the product selected by the user

        public List<Product> GetSingleProductById(int _productId)
        {
            //Create Product to be returned
            List<Product> ReturnedProduct = new List<Product>();
            //Create the query that will be passed to the database
            string SingleProductQuery =
                        $@"SELECT Id, CustomerId, Title, Description, Price, Quantity, DateAdded
                        FROM Product
                        WHERE Id = '{_productId}'";

            //query the database

            db.Query(SingleProductQuery, (SqliteDataReader handler) =>
               {
                   while (handler.Read())
                   {
                       ReturnedProduct.Add(new Product(handler.GetInt32(0), handler.GetInt32(1), handler.GetString(2), handler.GetString(3),handler.GetInt32(4), handler.GetInt32(5), handler.GetString(6)));
                   }
               });
               return ReturnedProduct;
        }

    }
}