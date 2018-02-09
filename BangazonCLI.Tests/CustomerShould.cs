//Author: Max Wolf
//Purpose: Test that the customers are being stored properly and can be retrieved
using System;
using Xunit;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using System.Collections.Generic;

namespace BangazonCLI.Tests
{
    public class CustomerShould
    {
        //creates a variable storing a test customer
        private Customer _customer;

        //uses the Customer class to add a new customer for testing
        public CustomerShould()
        {


        }

        //Test for getting all customers
        [Fact]
        public void GetAllCustomers()
        {
            //a new instance of the customer manager/database interface to be used here
            CustomerManager manager = new CustomerManager();
            //add the customer to the database and store the returned Id as a variable to use in the test customer object created below
            int _id = manager.Add("name", "street", "city", "state", "zip", "phone");
            //uses the GetAllCustomers method on the CustomerManager to store the results in a list
            List<Customer> allCustomers = manager.GetAllCustomers();

            //create test customer
            _customer = new Customer(
                _id,
                "name",
                "street",
                "city",
                "state",
                "zip",
                "phone"
            );
            //Asserts that the list created in the line ablove contains the customer added to the customer list
            Assert.Equal(_customer.Id, allCustomers[allCustomers.Count - 1].Id);
            Assert.Equal(_customer.Name, allCustomers[allCustomers.Count - 1].Name);
            Assert.Equal(_customer.Street, allCustomers[allCustomers.Count - 1].Street);
            Assert.Equal(_customer.City, allCustomers[allCustomers.Count - 1].City);
            Assert.Equal(_customer.State, allCustomers[allCustomers.Count - 1].State);
            Assert.Equal(_customer.Zip, allCustomers[allCustomers.Count - 1].Zip);
            Assert.Equal(_customer.Phone, allCustomers[allCustomers.Count - 1].Phone);
        }

        // //Tests getting a single customer
        // [Fact]
        // public void GetSingleCustomer()
        // {
        //     //a new instance of the customer manager to be used here
        //     CustomerManager manager = new CustomerManager();

        //     //adds the customer created above to the customer table
        //     manager.Add(_customer);

        //     //stores the results of the GetSingleCustomer method in the manager in a Customer variable
        //     Customer singleCustomer = manager.GetSingleCustomer(1);

        //     //Multiple assert statments to confirm that the customer added to the customer table in the same one retrieved
        //     Assert.Equal(1, singleCustomer.Id);
        //     Assert.Equal("Rang Dipkin", singleCustomer.Name);
        //     Assert.Equal("123 Derp Way", singleCustomer.Street);
        //     Assert.Equal("Derpville", singleCustomer.City);
        //     Assert.Equal("TN", singleCustomer.State);
        //     Assert.Equal("12345", singleCustomer.Zip);
        //     Assert.Equal("1234567890", singleCustomer.Phone);

        // }
    }
}