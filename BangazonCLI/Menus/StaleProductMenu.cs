//Chris Miller
//CLI Menu to add a product to the active order for the customer

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class StaleProductMenu
    {
        public static void Show()
        {
            StaleProductManager spm = new StaleProductManager();

            List<Product> StaleProductList = spm.GetStaleProducts();

            Console.Clear();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("           BANGAZON STALE PRODUCT REPORT");
            Console.WriteLine("*******************************************************");
            Console.WriteLine();
            Console.WriteLine();

            if(StaleProductList.Count == 0)
            {
                Console.WriteLine("There are no stale products to report");
            } else
            {
                StaleProductList.ForEach(p =>
                    {
                        Console.WriteLine($"{StaleProductList.IndexOf(p) + 1} : ");
                        
                    }
                );
            }
            
        }
    }
}