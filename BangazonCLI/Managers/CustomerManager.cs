//Author: Max Wolf
//Purpose: Customer manager to add to and query the customer table
using System.Collections.Generic;
using BangazonCLI.Models;
using System.Linq;

namespace BangazonCLI.Managers
{
    public class CustomerManager
    {
        //creates a new list (table) to store all the customers
        private List<Customer> _customerTable = new List<Customer>();

        public void Add(Customer custy)
        {
            _customerTable.Add(custy);
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