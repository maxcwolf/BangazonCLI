using System;
using Xunit;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using System.Collections.Generic;

namespace BangazonCLI.Tests
{
    public class CustomerShould
    {
        private Customer _customer;
        public CustomerShould()
        {

            _customer = new Customer(
                1,
                "Rang Dipkin",
                "123 Derp Way",
                "Derpville",
                "TN",
                12345,
                1234567890
            );
        }


        [Fact]
        public void GetAllCustomers()
        {
            CustomerManager manager = new CustomerManager();
            manager.Add(_customer);
            List<Customer> allCustomers = manager.GetAllCustomers();

            Assert.Contains(_customer, allCustomers);
        }

        [Fact]
        public void GetSingleCustomer()
        {
            CustomerManager manager = new CustomerManager();
            manager.Add(_customer);
            Customer singleCustomer = manager.GetSingleCustomer(1);


            Assert.Equal(1, singleCustomer.Id);
            Assert.Equal("Rang Dipkin", singleCustomer.Name);
            Assert.Equal("123 Derp Way", singleCustomer.Street);
            Assert.Equal("Derpville", singleCustomer.City);
            Assert.Equal("TN", singleCustomer.State);
            Assert.Equal(12345, singleCustomer.Zip);
            Assert.Equal(1234567890, singleCustomer.Phone);



        }
    }
}