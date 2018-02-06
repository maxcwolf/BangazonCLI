using System;
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

            ProductManager pm = new ProductManager();

            Product NewProduct = new Product();

            pm.AddProduct(NewProduct);


            Assert.Contains(NewProduct, pm.GetCustomerProducts(1));
        }

        public void ListCustomerProducts()
        {
            
        }
    }
}