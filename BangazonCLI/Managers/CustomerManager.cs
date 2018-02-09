//Author: Max Wolf
//Purpose: Customer manager to add to and query the customer table
using System.Collections.Generic;
using BangazonCLI.Models;
using System.Linq;
using BangazonCLI.Data;

namespace BangazonCLI.Managers
{
    public class CustomerManager
    {
        //creates a new list (table) to store all the customers
        private List<Customer> _customerTable = new List<Customer>();

        public int Add(string name, string street, string city, string state, string zip, string phone)
        {
            //create new database interface instance
            DatabaseInterface db = new DatabaseInterface();

            //create sql string and store in variable
            string _sql = $"INSERT INTO Customer VALUES (null, '{name}', '{street}', '{city}', '{state}', '{zip}', '{phone}');";

            //use insert method on the db interface and pass in the sql string
            return db.Insert(_sql);

        }

        //Method to get all customers (return customer table)
        public List<Customer> GetAllCustomers ()
        {
            return _customerTable;
        }

        //Method to get a single customer (returns a single customer from the id passed in)
        public Customer GetSingleCustomer(int id)
        {
            return _customerTable.Where(j => j.Id == id).Single();
        }
    }
}