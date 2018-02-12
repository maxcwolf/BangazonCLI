//Paul Ellis
//CLI Menu to generate and display a product popularity report

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class ProductPopularityReportMenu
    {
        //static method to be referenced when writing to console. Pass in integer of number of stars desired to be written on a line
        //saves you from having to count out the number of stars in console.writeline commands
        static string Stars(int StarsWanted)
        {
            string StarString = "*";
            for (int i = 0; i < StarsWanted - 1; i++)
            {
                StarString = string.Concat(StarString, "*");
            }
            return StarString;
        }
        //stores count of which row is being used from the returned data
        static int returnCount = 0;
        public static void Show()
        {
            /*Create new instance of the Product Popularity Report Manager with production database path passed in
            to create connection string*/
            ProductPopularityReportManager rm = new ProductPopularityReportManager("BANGAZON_CLI");
            //GenerateReport() will return the top three popular products with associated data
            List<ProductPopularityReportViewModel> TopThree = rm.GenerateReport();
            //holds a string of 61 stars for writing a line as wide as the total spaces of the columns in the table
            string StarLine = Stars(61);
            //Build the prompt
            Console.Clear();
            Console.WriteLine("Top Three Products and Associated Sales Data");
            Console.WriteLine($"{StarLine}");
            //write columns with set widths.  - value denotes left alignment
            Console.WriteLine("{0, -20}{1, -11}{2, -15}{3, -15}", "Product", "Orders", "Purchasers", "Revenue");
            Console.WriteLine($"{StarLine}");
            TopThree.ForEach(r =>
                {
                    //for each row returned:
                    //add to the return count
                    returnCount++;
                    //Store the returned product name.  If longer than 20 char, must be manipulated
                    string ProductName = r.Product;
                    //If product name is longer than 20 char
                    if(r.Product.Length >= 20) 
                    {
                        //set a remove count(second required parameter for .Remove()). 
                        int RemoveCount = r.Product.Length - 16;
                        //Column width is 20 char, so remove starting at 17th character and add elipsis
                        ProductName = r.Product.Remove(16, RemoveCount) + "...";
                    }
                    //if the return count isn't the last one, write the row
                    if (returnCount != TopThree.AsEnumerable().LongCount())
                    {
                        Console.WriteLine($"{ProductName,-20}{r.Orders,-11}{r.Purchasers,-15}{r.Revenue,-15}");
                    }
                    //if the return count is the last one, we want a star line above it
                    else
                    {
                        Console.WriteLine($"{StarLine}");
                        Console.WriteLine($"{ProductName,-20}{r.Orders,-11}{r.Purchasers,-15}{r.Revenue,-15}");
                    }
                }
            );
            //reset the return count
            returnCount = 0;
            Console.WriteLine("Press any key to return to main menu");
            Console.WriteLine("");
            Console.Write("->");
            //if the user presses any key, show the main menu
            Console.ReadKey();
            MainMenu.Show();
        }
    }
}