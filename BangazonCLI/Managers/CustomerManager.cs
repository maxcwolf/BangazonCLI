//Author: Max Wolf
//Purpose: Customer manager to add to and query the customer table
using System.Collections.Generic;
using BangazonCLI.Models;
using System.Linq;
using BangazonCLI.Data;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    public class CustomerManager
    {
        //creates a private db variable
        private DatabaseInterface _db;

        public CustomerManager(string connection_string = "BANGAZON_CLI")
        {
            //instantiate the databaseInterface with the connection_string
            _db = new DatabaseInterface(connection_string);
        }

        public int Add(string name, string street, string city, string state, string zip, string phone)
        {

            //create sql string and store in variable
            string _sql = $"INSERT INTO Customer VALUES (null, '{name}', '{street}', '{city}', '{state}', '{zip}', '{phone}');";

            //use insert method on the db interface and pass in the sql string
            return _db.Insert(_sql);

        }

        //Method to get all customers (return customer table)
        public List<Customer> GetAllCustomers ()
        {
            List<Customer> AllCustomers = new List<Customer>();

            _db.Query(
                "SELECT * FROM Customer",
                (SqliteDataReader reader) => {
                    //Callback function to iterate through the returned object
                    //Create a new instance of the OrderProduct class by scraping the id from column 0
                    //Add the new Customer to the list
                    while (reader.Read ())
                    {
                        AllCustomers.Add(new Customer(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6)
                        ));
                    }
                }
            );
            //return the list of all customers
            return AllCustomers;
        }

        //Method to get a single customer (returns a single customer from the id passed in)
        public List<Customer> GetSingleCustomer(int id)
        {
            List<Customer> SingleCustomer = new List<Customer>();

            _db.Query(
                $"SELECT * FROM Customer WHERE Customer.Id = {id}",
                (SqliteDataReader reader) => {
                    //Callback function to iterate through the returned object
                    //Create a new instance of the OrderProduct class by scraping the id from column 0
                    //Add the new Customer to the list
                    while (reader.Read ())
                    {
                        SingleCustomer.Add(new Customer(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6)
                        ));
                    }
                }
            );
            //return the list of all customers
            return SingleCustomer;
        }
    }
}