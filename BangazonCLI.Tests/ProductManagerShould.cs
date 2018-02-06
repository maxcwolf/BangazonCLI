using System;
using Xunit;
using BangazonCLI;
using System.Collections.Generic;

namespace BangazonCLI.Tests
{
    public class ProductManagerShould
    {
        private Product _product;
        public ProductManagerShould()
        {
            /*
                Properties of Product
                    - <int> Id
                    - <int> CustomerId (foreign key)
                    - <string> Title
                    - <string> Description
                    - <int> Price
                    - <int> Quantity
                    - <datetime> DateAdded
             */
             _product = new Product(
                 1,
                 1,
                 "Plumbus",
                 "Travel Sized Plumbus",
                 1500,
                 1,
                 "2018-02-07"
             );
        }

        [Fact]
        public void AddProductToProductTable()
        {
            ProductManager prodManager = new ProductManager();
            Product NewProduct = _product;
            ProdManager.AddProductToCustomer(_product);
            Assert.Contains(NewProduct, ProdManger.getActiveCustomerProducts);
        }
    }
}