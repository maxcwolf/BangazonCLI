using System;
using System.Collections.Generic;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        public List<Product> ProductList =  new List<Product>();

        public void AddProduct(Product NewProduct)
        {
            ProductList.Add(NewProduct);
        }
    }
}