//Author: Ray Medrano //Purpose: This Class handles all operations dealing with products
using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        public List<Product> ProductList =  new List<Product>();

        //This method adds a product to the database with the following arguments
        // NewProduct  = The default product object (see the constructor on the product class)
        public void AddProduct(Product NewProduct)
        {
            //add product to product list
            ProductList.Add(NewProduct);
        }

        //This method returns a list of products from the database for the active customer with the follwing argument
        // id = the customer id
        public List<Product> GetCustomerProducts(int id)
        {
            //return a list of products where CustomerId = id
            return ProductList.Where(p => p.CustomerId == id).ToList();
        }
    }
}