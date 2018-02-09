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

        [Fact]
        public void AddProductToProductTable()
        {
            //create instances of both the productManager and a new product
            ProductManager pm = new ProductManager();

            //Use the AddProduct method to add a new product
            int _id = pm.AddProduct(1, "Refrigerator", "A Refrigerator", 100000, 1);

            //Create a NewProduct For Comparison of the database entry
            Product NewProduct = new Product(_id, 1, "Refrigerator" , "A Refrigerator",100000, 1, new DateTime(2018,02,09));

            List<Product> allproducts = pm.GetCustomerProducts(_id);

            //Assert that the Product List contains the new product that was added
            Assert.Equal(NewProduct.Id, allproducts[allproducts.Count-1].Id);
        }

        [Fact]
        public void FindAllProductsNotForActiveCustomer()
        {
            //create instance of ProductManager to use for test
           ProductManager pm = new ProductManager();


           //create a new product with a customer id of 1
           Product NewProduct = new Product(10,1,"NewProduct2", "This is a dummy Product2",42000, 4, new DateTime(2018,2,09));


            //the NewProduct should not be on the GetNonActiveUserProduct list
           Assert.DoesNotContain(NewProduct, pm.GetNonActiveUserProduct(1));
        }

    }
}