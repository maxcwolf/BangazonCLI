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
        private OrderProductManager opm {get; set;}

        //Constructor to instatiate ProductManager
        public ProductManagerShould()
        {
            this.pm = new ProductManager("BANGAZON_CLI_TEST");
            this.opm = new OrderProductManager("BANGAZON_CLI_TEST");
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
            Product CompareProduct1 = new Product(_id,8,"ToBeDeleted","A Product To Be Deleted",100000, 1,DateString);

            //Delete a product
            pm.DeleteCustomerProduct(_id);

            //Knowing That Product creates is in the database - assert that it has been removed
            Assert.DoesNotContain(CompareProduct1, pm.GetCustomerProducts(8));

            //Add New Product
            int _id2 = pm.AddProduct(8,"NotToBeDeleted","A Product To Not Be Deleted",100000, 1);

            //Add a product to the OrderProduct Table
            opm.Add(1,_id2);

            //Create Second Product To compare
            Product CompareProduct2 = new Product(_id2,8,"NotToBeDeleted","A Product To Not Be Deleted",100000, 1,DateString);

            //Attempt to delete product
            pm.DeleteCustomerProduct(_id2);

            //Get a list of customer products from the database
            List<Product> AllProduct = pm.GetCustomerProducts(8);
            //Assert that the last product added, is still there and not deleted by equating the id's and descriptions
            Assert.Equal(CompareProduct2.Id, AllProduct[AllProduct.Count-1].Id);
            Assert.Equal(CompareProduct2.Description, AllProduct[AllProduct.Count-1].Description);
        }


        [Fact]
        public void GetSingleProductById()
        {
            //create a list to hold product
            List<Product> ProductList = new List<Product>();



            Assert.Contains(ProductList,pm.GetSingleProduct(_productId));
        }

    }
}