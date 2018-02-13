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
            //Instantiate the StaleProductManager - defaults to the production database
            StaleProductManager spm = new StaleProductManager();

            //Save the results of the Stale Product Query to a List
            List<StaleProductViewModel> StaleProductList = spm.GetStaleProducts();

            //Write a header
            Console.Clear();
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine("                         BANGAZON STALE PRODUCT REPORT");
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine();

            //Show a mesage if there are no products to display
            if (StaleProductList.Count == 0)
            {
                Console.WriteLine("                   There are no stale products to report");
            }
            else
            {
                //Write a header for the columns
                Console.WriteLine("{0, -20}{1, -25}{2, -15}{3, -15}", "Owner", "Product", "Total QTY", "Available QTY");
                Console.WriteLine("*****************************************************************************");
                StaleProductList.ForEach(p =>
                    {
                        //Truncate the Customer Name if need be
                        if (p.Title.Length >= 20)
                        {
                            //set a remove count(second required parameter for .Remove()). 
                            int RemoveCount = p.Title.Length - 16;
                            //Column width is 20 char, so remove starting at 17th character and add elipsis
                            p.Title = p.Title.Remove(16, RemoveCount) + "...";
                        }

                        //Truncate the Product Name if need be
                        if (p.Owner.Length >= 20)
                        {
                            //set a remove count(second required parameter for .Remove()). 
                            int RemoveCount = p.Owner.Length - 16;
                            //Column width is 20 char, so remove starting at 17th character and add elipsis
                            p.Owner = p.Owner.Remove(16, RemoveCount) + "...";
                        }

                        //Write the results
                        Console.WriteLine("{0, -20}{1, -25}{2, -15}{3, -15}", p.Owner, p.Title, p.Quantity, p.Available);
                    }
                );
            }

            Console.WriteLine();

            //Propt the user and wait for response before returning to the main menu
            Console.WriteLine("Press Any Key To Return to Main Menu");
            Console.ReadKey();
            MainMenu.Show();
        }
    }
}