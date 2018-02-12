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

        [Fact]
        public void CheckForProductsOnOrderProductsTable()
        {
            //create a variable to hold the expected answer
            int AmountInOrder = 0;
            //create a variable to hold the productId
            int ProductId = 9;
            Assert.Equal(AmountInOrder,pm.CheckForProductOnOrder(ProductId));

            //test to make sure that if it does exist it returns the expected amount
            // create a variable to hold the expected amount
            int ProductsInTable = 5;
            //create a new variable to hold the productid
            int NewProductId = 1;

            Assert.Equal(ProductsInTable,pm.CheckForProductOnOrder(NewProductId));
        }

        [Fact]
        public void ProductShouldBeDeletedFromDatabase ()
        {   //Add a product to be deleted and return it's Id
            int _id = pm.AddProduct(8, "ToBeDeleted", "A Product To Be Deleted", 100000, 1);

            //create date time to use in product comparison
            var format = "yyyy-MM-dd";
            DateTime Now = DateTime.Now;

            //Convert DateTime to String
            String DateString = Now.ToString(format);

            //Create Product Comparison
            Product CompareProduct = new Product(_id,8,"ToBeDeleted","A Product To Be Deleted",100000, 1,DateString);

            //Delete a product
            pm.DeleteCustomerProduct(_id);

            //Get a list of products for a customer
            List<Product> CustomerProducts = pm.GetCustomerProducts(8);

            Assert.DoesNotContain(CustomerProducts, pm.GetCustomerProducts(8));
        }
    }
}