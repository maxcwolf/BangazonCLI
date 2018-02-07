//Author: Chris Miller
//Purpose: CLI menue to expose features after Active User is chosen

using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI.Menus
{
    public class FeatureMenu
    {
        public static void Show(int ActiveUserId)
        {
            //Clear any prior menu
            Console.Clear();
            //Main menu that user is initially presented with
            Console.WriteLine("Active User : ");
            Console.WriteLine("*********************************");
            Console.WriteLine("1. Create a payment option");
            Console.WriteLine("2. Add product to sell");
            Console.WriteLine("3. Add product to shopping cart");
            Console.WriteLine("4. Complete an order");
            Console.WriteLine("5. Remove customer product");
            Console.WriteLine("6. Update product information");
            Console.WriteLine("7. Show stale products");
            Console.WriteLine("8. Show customer revenue report");
            Console.WriteLine("9. Show overall product popularity");
            Console.WriteLine("10. Leave Bangazon!");
            Console.WriteLine("Press 'Q' to return to Main Menu");
            Console.Write("> ");

            var Result = Console.ReadLine();

            if (Result == "q" || Result == "Q")
            {
                MainMenu.Show();
            }
            else
            {
                switch(Result)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}