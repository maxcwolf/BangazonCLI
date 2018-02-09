//Author: Ray Medrano   //Purpose: This Will Test the ProductManager
using System;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

namespace BangazonCLI.Tests
{
    public class ProductManagerShould
    {

        //Create global variables for tests
        private ProductManager pm {get; set;}

        //Constructor to instatiate ProductManager
        public ProductManagerShould()
        {
            this.pm = new ProductManager("BANGAZON_CLI_TEST");
        }
        [Fact]
        public void AddProductToProductTable()
        {

            //Use the AddProduct method to add a new product
            int _id = pm.AddProduct(1, "Refrigerator", "A Refrigerator", 100000, 1);

            //Create a datetime variable to pass to my product constructors to test
            var format = "yyyy-MM-dd";
            DateTime Now = DateTime.Now;
            //Convert DateTime to String
            String DateString = Now.ToString(format);

            //Create a NewProduct For Comparison of the database entry

            Product NewProduct = new Product(_id, 1, "Refrigerator" , "A Refrigerator",100000, 1, DateString);

            List<Product> allproducts = pm.GetCustomerProducts(1);

            //Assert that the Product List contains the new product that was added
            Assert.Equal(NewProduct.Id, allproducts[allproducts.Count-1].Id);
            Assert.Equal(NewProduct.CustomerId, allproducts[allproducts.Count-1].CustomerId);
            Assert.Equal(NewProduct.Description, allproducts[allproducts.Count-1].Description);
            Assert.Equal(NewProduct.Price, allproducts[allproducts.Count-1].Price);
            Assert.Equal(NewProduct.Quantity, allproducts[allproducts.Count-1].Quantity);
            Assert.Equal(NewProduct.DateAdded, allproducts[allproducts.Count-1].DateAdded);
        }

        [Fact]
        public void FindAllProductsNotForActiveCustomer()
        {
            //Use the AddProduct method to add a new product
            int _id = pm.AddProduct(1, "Washer", "A Washer", 100000, 1);

           //Create a datetime variable to pass to my product constructors to test
            var format = "yyyy-MM-dd";
            DateTime Now = DateTime.Now;
            //Convert DateTime to String
            String DateString = Now.ToString(format);

           //create a new product with a customer id of 1
           Product NewProduct = new Product(_id,1,"Washer", "A Washer", 100000, 1,DateString);


            //the NewProduct should not be on the GetNonActiveUserProduct list
           Assert.DoesNotContain(NewProduct, pm.GetNonActiveUserProduct(1));
        }

    }
}