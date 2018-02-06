using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        public List<Product> ProductList =  new List<Product>();

        //This method adds a product to the database, given a product is passed as an argument
        public void AddProduct(Product NewProduct)
        {
            //add product to product list
            ProductList.Add(NewProduct);
        }

        //This method returns a list of products from the database for the active customer when customer id is passed as an arugument
        public List<Product> GetCustomerProducts(int id)
        {
            //return a list of products where CustomerId = id
            return ProductList.Where(p => p.CustomerId == id).ToList();
        }
    }
}